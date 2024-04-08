using Microsoft.Xna.Framework.Content;

namespace GameEngine.Resource;

public class AssetServerRes
{
    public ContentManager Content { get; set; }
    
    private static AssetServerRes? _instance;
    
    private AssetServerRes() { }

    public static AssetServerRes Instance => _instance ??= new AssetServerRes();
}