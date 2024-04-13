using Arch.Core;
using GameEngine.Components;
using GameEngine.Components.Camera;
using GameEngine.Resource;
using GameEngine.SystemEvent;
using Microsoft.Xna.Framework;

namespace GameEngine.Plugins;

/// <summary>
/// Плагин камеры
/// </summary>
public class DefaultCameraPlugin : IPlugin
{
    public void Create(App app)
    {
        app.AddSystem<OnUpdate, CameraRender>();
    }
}

/// <summary>
/// Система отвечающая за запись информации для матрицы отображения в ресурсе SpriteBatch
/// </summary>
public class CameraRender : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<Transform2D, Camera, Camera2D>();

    public void Run(World world)
    {
        world.Query(in _description, (ref Transform2D transform, ref Camera camera, ref Camera2D camera2D) =>
        {
            if (!camera.IsActive) return;

            var spriteBatchViewport = SpriteBatchRes.Instance.SpriteBatch.GraphicsDevice.Viewport;

            SpriteBatchRes.Instance.TransformMatrix = Matrix.CreateTranslation(new Vector3(-transform.Translation.X, -transform.Translation.Y, 0)) *
                              Matrix.CreateRotationZ(-transform.Rotation) *
                              Matrix.CreateScale(camera2D.Scale) *
                              Matrix.CreateTranslation(new Vector3(spriteBatchViewport.Width * 0.5f, spriteBatchViewport.Height * 0.5f, 0));
        });
    }
}