using Arch.Core;
using GameEngine.Plugins;
using GameEngine.Resource;
using GameEngine.SystemEvent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine;

public sealed class App : Game
{
    private readonly List<ISystem> _onStartUpSystems = [];
    private readonly List<ISystem> _onLoadSystems = [];
    private readonly List<ISystem> _onUpdateSystems = [];
    private readonly List<ISystem> _onDrawSystems = [];

    private readonly World _world = World.Create();

    private readonly GraphicsDeviceManager _graphics;

    public App(string contentRootDir)
    {
        Content.RootDirectory = contentRootDir;
        _graphics = new GraphicsDeviceManager(this);
    }

    protected override void Initialize()
    {
        InitWindowSettings();

        SpriteBatchRes.Instance.SpriteBatch = new SpriteBatch(GraphicsDevice);
        // SpriteBatchRes.Instance.SpriteBatch.GraphicsDevice.SamplerStates[0] = SamplerState.LinearClamp;
        AssetServerRes.Instance.Content = Content;
        ViewportRes.Instance.Viewport = GraphicsDevice.Viewport;

        foreach (var system in _onStartUpSystems)
        {
            system.Run(_world);
        }

        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        foreach (var system in _onLoadSystems)
        {
            system.Run(_world);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        foreach (var system in _onUpdateSystems)
        {
            system.Run(_world);
        }

        TimeRes.Instance.DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardRes.Instance.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _graphics.GraphicsDevice.Clear(WindowRes.Instance.ClearColor);

        SpriteBatchRes.Instance.SpriteBatch.Begin(transformMatrix: SpriteBatchRes.Instance.TransformMatrix);

        foreach (var system in _onDrawSystems)
        {
            system.Run(_world);
        }
        SpriteBatchRes.Instance.SpriteBatch.End();

        base.Draw(gameTime);
    }

    public App AddPlugin<T>() where T : IPlugin, new()
    {
        var plugin = new T();

        plugin.Create(this);

        return this;
    }

    public App AddSystem<TEvent, T>() where TEvent : IEvent where T : ISystem, new()
    {
        var system = new T();

        var typeTEvent = typeof(TEvent);

        switch (typeTEvent.Name)
        {
            case nameof(OnStart):
                _onStartUpSystems.Add(system);
                break;
            case nameof(OnUpdate):
                _onUpdateSystems.Add(system);
                break;
            case nameof(OnLoad):
                _onLoadSystems.Add(system);
                break;
            case nameof(OnDraw):
                _onDrawSystems.Add(system);
                break;
            default:
                throw new Exception();
        }

        return this;
    }

    private void InitWindowSettings()
    {
        Window.Title = WindowRes.Instance.Title;

        _graphics.PreferredBackBufferWidth = WindowRes.Instance.Width;
        _graphics.PreferredBackBufferHeight = WindowRes.Instance.Height;

        _graphics.ApplyChanges();
    }
}