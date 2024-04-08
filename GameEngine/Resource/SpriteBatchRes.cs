using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Resource;

public class SpriteBatchRes
{
    public SpriteBatch SpriteBatch { get; set; }
    public Matrix? TransformMatrix { get; set; } = null;
    
    private static SpriteBatchRes? _instance;
    
    private SpriteBatchRes() { }

    public static SpriteBatchRes Instance => _instance ??= new SpriteBatchRes();
}