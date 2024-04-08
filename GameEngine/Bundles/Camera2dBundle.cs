using Arch.Core;
using GameEngine.Components;
using GameEngine.Components.Camera;

namespace GameEngine.Bundles;

/// <summary>
/// Бандл который создает объект камеры с компонентами
///
/// <seealso cref="Camera"/>
/// <seealso cref="Camera2D"/>
/// <seealso cref="Transform2D"/>
/// </summary>
public static class Camera2dBundle
{
    public static Entity Create(World world, Camera camera, Camera2D camera2D, Transform2D transform2D)
    {
        return world.Create(
            camera,
            camera2D,
            transform2D
        );
    }
}