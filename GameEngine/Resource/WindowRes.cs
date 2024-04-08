using Microsoft.Xna.Framework;

namespace GameEngine.Resource;

public class WindowRes
{
    public string Title { get; private set; } = "Moongame Title";
    public int Width { get; private set; } = 800;
    public int Height { get; private set; }  = 600;
    // TODO: нужно чтобы это начало работать!!!
    public bool Fullscreen { get; private set; } = false;
    public Color ClearColor { get; private set; } = Color.Black;

    private static WindowRes? _instance;
    
    private WindowRes() { }

    public void SetParams(string title, int width, int height, bool fullscreen = false)
    {
        Title = title;
        Width = width;
        Height = height;
        Fullscreen = fullscreen;
    }

    public void SetClearColor(Color color)
    {
        ClearColor = color;
    }

    public void SwitchToFullscreen()
    {
        Fullscreen = !Fullscreen;
    }

    public static WindowRes Instance => _instance ??= new WindowRes();
}