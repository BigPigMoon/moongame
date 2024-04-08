using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Resource;

public class SpriteBatchRes
{
    public SpriteBatch? SpriteBatch { get; set; }
    
    private static SpriteBatchRes? _instance;
    
    private SpriteBatchRes() { }

    public static SpriteBatchRes Instance => _instance ??= new SpriteBatchRes();
}