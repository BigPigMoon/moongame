using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Resource;

public class ViewportRes
{
    public Viewport Viewport { get; set; }
    
    private static ViewportRes? _instance;
    
    private ViewportRes() { }

    public static ViewportRes Instance => _instance ??= new ViewportRes();
}