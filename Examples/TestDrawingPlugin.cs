using System;
using Arch.Core;
using GameEngine;
using GameEngine.Bundles;
using GameEngine.Components;
using GameEngine.Plugins;
using GameEngine.Resource;
using GameEngine.SystemEvent;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Arch.Core.Extensions;
using Microsoft.Xna.Framework.Input;

namespace Examples;

public struct Ball { }

public struct BallVelocity
{
    public float Dx, Dy;
}

public class TestDrawingPlugin : IPlugin
{
    public void Create(App app)
    {
        app.AddSystem<OnLoad, SpawnBall>();
        app.AddSystem<OnUpdate, MoveBallOnKey>();
        app.AddSystem<OnUpdate, MoveBallOnArrow>();
        // app.AddSystem<OnUpdate, MoveBall>();
    }
}

public class SpawnBall : ISystem
{
    public void Run(World world)
    {
        var ballTexture = AssetServerRes.Instance.Content.Load<Texture2D>("ball");
        const float scaleFactor = 0.01f;
        
        SpriteBundle.Create(
            world,
            new Sprite(),
            new Transform2D()
            {
                Scale = new Vector2(scaleFactor),
            },
            ballTexture,
            Visibility.Visible
        ).Add(
            new Ball(),
            new BallVelocity() {Dx =  1, Dy = 1}
        );
        
        SpriteBundle.Create(
            world,
            new Sprite(),
            new Transform2D()
            {
                Scale = new Vector2(scaleFactor),
            },
            ballTexture,
            Visibility.Visible
        ).Add(
            new Ball(),
            new BallVelocity() {Dx =  1, Dy = 1}
        );
    }
}

public class MoveBall : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<Ball, BallVelocity, Transform2D, Texture2D>();

    public void Run(World world)
    {
        var windowWidth = ViewportRes.Instance.Viewport.Width;
        var windowHeight = ViewportRes.Instance.Viewport.Height;
        var dt = TimeRes.Instance.DeltaTime;
        const int speed = 100;
        
        world.Query(in _description, (ref BallVelocity ballVelocity, ref Transform2D transform, ref Texture2D texture) =>
        {
            var scaleVal = transform.Scale.X;
            var ballSize = new Vector2(texture.Width * scaleVal / 2, texture.Height * scaleVal / 2);
            
            if (transform.Translation.X - ballSize.X < 0 || transform.Translation.X + ballSize.X >= windowWidth)
            { 
                ballVelocity.Dx *= -1;
            }

            if (transform.Translation.Y - ballSize.Y < 0 || transform.Translation.Y + ballSize.Y >= windowHeight)
            { 
                ballVelocity.Dy *= -1;
            }

            transform.Translation.X += ballVelocity.Dx * dt * speed;
            transform.Translation.Y += ballVelocity.Dy * dt * speed;
        });
    }
}

public class MoveBallOnKey : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<Ball, Transform2D, Texture2D>();
    private readonly Random _random = new();
    
    public void Run(World world)
    {
        world.Query(in _description, (ref Transform2D transform, ref Texture2D texture) =>
        {
            var windowWidth = ViewportRes.Instance.Viewport.Width;
            var windowHeight = ViewportRes.Instance.Viewport.Height;
            
            if (KeyboardRes.Instance.IsKeyJustPressed(Keys.Space))
            {
                var scaleFactor = transform.Scale.X;
                var ballSize = new Vector2(texture.Width * scaleFactor / 2, texture.Height * scaleFactor / 2);
                var newRandomPos = new Vector2(_random.Next((int)ballSize.X, (int)(windowWidth - ballSize.X)), _random.Next((int)ballSize.Y, (int)(windowHeight - ballSize.Y)));

                transform.Translation = newRandomPos;
            }
        });
    }
}

public class MoveBallOnArrow : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<Ball, Transform2D>();
    
    public void Run(World world)
    {
        world.Query(in _description, (ref Transform2D transform) =>
        {
            var dt = TimeRes.Instance.DeltaTime;
            const float speed = 200;

            var dir = Vector2.Zero;
            
            if (KeyboardRes.Instance.IsKeyPressed(Keys.Left))
            {
                dir.X -= 1;
            }
            else if (KeyboardRes.Instance.IsKeyPressed(Keys.Right))
            {
                dir.X += 1;
            }
            
            if (KeyboardRes.Instance.IsKeyPressed(Keys.Up))
            {
                dir.Y -= 1;
            }
            else if (KeyboardRes.Instance.IsKeyPressed(Keys.Down))
            {
                dir.Y += 1;
            }
            
            if (dir != Vector2.Zero)
                dir.Normalize(); 

            transform.Translation += dir * dt * speed;
        });
    }
}