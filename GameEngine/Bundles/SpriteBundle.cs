using Arch.Core;
using GameEngine.Components;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Bundles;

public static class SpriteBundle
{
    public static Entity Create(World world, Sprite sprite, Transform2D transform2D, Texture2D texture, Visibility visibility = Visibility.Visible)
    {
        return world.Create(
            sprite,
            transform2D,
            texture,
            visibility
        );
    }
}