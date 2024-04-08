using Arch.Core;
using GameEngine;
using GameEngine.Bundles;
using GameEngine.Components;
using GameEngine.Components.Camera;
using GameEngine.Plugins;
using GameEngine.Resource;
using GameEngine.SystemEvent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Examples;

public class CameraPlugin : IPlugin
{
    public void Create(App app)
    {
        app.AddSystem<OnStart, SpawnCamera>();
        app.AddSystem<OnUpdate, MoveCamera>();
    }
}

public class MoveCamera : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<Camera, Transform2D, Camera2D>();
    private const float Speed = 200;

    public void Run(World world)
    {
        world.Query(in _description, (ref Transform2D transform, ref Camera2D camera2D) =>
        {
            var dt = TimeRes.Instance.DeltaTime;

            var dir = Vector2.Zero;
            
            if (KeyboardRes.Instance.IsKeyPressed(Keys.A))
            {
                dir.X -= 1;
            }
            else if (KeyboardRes.Instance.IsKeyPressed(Keys.D))
            {
                dir.X += 1;
            }
            
            if (KeyboardRes.Instance.IsKeyPressed(Keys.W))
            {
                dir.Y -= 1;
            }
            else if (KeyboardRes.Instance.IsKeyPressed(Keys.S))
            {
                dir.Y += 1;
            }

            if (KeyboardRes.Instance.IsKeyJustPressed(Keys.U))
            {
                transform.Rotation += 0.1f;
            }
            if (KeyboardRes.Instance.IsKeyJustPressed(Keys.Y))
            {
                transform.Rotation -= 0.1f;
            }
            
            if (dir != Vector2.Zero)
                dir.Normalize(); 

            transform.Translation += dir * dt * Speed;
        });
    }
}

public class SpawnCamera : ISystem
{
    public void Run(World world)
    {
        Camera2dBundle.Create(world, new Camera(), new Camera2D(), new Transform2D());
    }
}