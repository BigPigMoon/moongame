using Arch.Core;
using Arch.Core.Extensions;
using GameEngine;
using GameEngine.Bundles;
using GameEngine.Components;
using GameEngine.Components.TimeUtils;
using GameEngine.Plugins;
using GameEngine.Resource;
using GameEngine.SystemEvent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Examples;

public class TestAnimPlugin : IPlugin
{
    public void Create(App app)
    {
        app.AddSystem<OnStart, SetupAnim>();
        app.AddSystem<OnUpdate, PlayAnim>();
    }
}

internal class Player { }

internal class SetupAnim : ISystem
{
    public void Run(World world)
    {
        var animTexture = AssetServerRes.Instance.Content.Load<Texture2D>("player_anim");

        SpriteBundle.Create(
            world,
            new Sprite
            {
                Rect = new Rectangle(0, 48 * 1, 48, 48)
            }, 
            new Transform2D
            {
                Scale = new Vector2(3)
            },
            animTexture
        ).Add(
            new Player(),
            new TimerComponent(0.1f, TimerMode.Repeating)
        );
    }
}

public class PlayAnim : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<Player, TimerComponent>();
    public void Run(World world)
    {
        world.Query(in _description, (ref Sprite sprite, ref TimerComponent timer) =>
        {
            if (timer.IsFinished && !timer.IsPaused)
            {
                if (timer.Mode == TimerMode.Once)
                {
                    timer.Pause();
                    return;
                }
                
                sprite.Rect.X += 48;
                
                if (sprite.Rect.X >= 48 * 6)
                {
                    sprite.Rect.X = 0;
                    //timer.Mode = TimerMode.Once;
                }
            }
        });
    }
}