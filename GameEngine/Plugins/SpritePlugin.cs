using Arch.Core;
using GameEngine.Components;
using GameEngine.Resource;
using GameEngine.SystemEvent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Plugins;

public class SpritePlugin : IPlugin
{
    public void Create(App app)
    {
        app.AddSystem<OnDraw, DrawSprite>();
    }
}

public class DrawSprite : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<Sprite, Transform2D, Texture2D, Visibility>();
    
    public void Run(World world)
    {
        world.Query(in _description, (ref Sprite sprite, ref Transform2D transform, ref Texture2D texture, ref Visibility visible) =>
        {
            var spriteBatch = SpriteBatchRes.Instance.SpriteBatch ?? throw new Exception("Please, init sprite batch in singleton");

            switch (visible)
            {
                case Visibility.Visible:
                    Draw(spriteBatch, sprite, texture, transform);
                    break;
                case Visibility.Hidden:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(visible), visible, "Can not agree visibility value");
            }
        });
    }

    private static void Draw(SpriteBatch spriteBatch, Sprite sprite, Texture2D texture, Transform2D transform)
    {
        var spriteEffect = SpriteEffects.None;

        if (sprite.FlipX) spriteEffect |= SpriteEffects.FlipHorizontally;
        if (sprite.FlipY) spriteEffect |= SpriteEffects.FlipVertically;

        var origin = GetOrigin(sprite.Anchor, texture);

        spriteBatch.Draw(
            texture: texture,
            position: transform.Translation,
            sourceRectangle: sprite.Rect == Rectangle.Empty ? null: sprite.Rect,
            color: sprite.Color,
            rotation: transform.Rotation,
            origin: origin,
            scale: transform.Scale,
            effects: spriteEffect,
            layerDepth: 0
        );
    }

    private static Vector2 GetOrigin(Anchor anchor, Texture2D texture)
    {
        return anchor switch
        {
            Anchor.Center => new Vector2(texture.Width / 2f, texture.Height / 2f),
            Anchor.BottomLeft => new Vector2(0, texture.Height),
            Anchor.BottomCenter => new Vector2(texture.Width / 2f, texture.Height),
            Anchor.BottomRight => new Vector2(texture.Width, texture.Height),
            Anchor.CenterLeft => new Vector2(0, texture.Height / 2f),
            Anchor.CenterRight => new Vector2(texture.Width, texture.Height / 2f),
            Anchor.TopLeft => Vector2.Zero,
            Anchor.TopCenter => new Vector2(texture.Width / 2f, 0),
            Anchor.TopRight => new Vector2(texture.Width, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(anchor), anchor, null)
        };
    }
}