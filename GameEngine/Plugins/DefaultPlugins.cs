namespace GameEngine.Plugins;

public class DefaultPlugins : IPlugin
{
    public void Create(App app)
    {
        app.AddPlugin<SpritePlugin>();
        app.AddPlugin<DefaultCameraPlugin>();
    }
}
