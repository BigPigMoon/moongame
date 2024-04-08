using Microsoft.Xna.Framework.Input;

namespace GameEngine.Resource;

public class KeyboardRes
{
    private KeyboardState _currentKeyboardState;
    private KeyboardState _previousKeyboardState;
    
    private static KeyboardRes? _instance;
    
    private KeyboardRes() { }

    public static KeyboardRes Instance => _instance ??= new KeyboardRes();
    
    public void Update()
    {
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();
    }

    public bool IsKeyJustPressed(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
    }

    public bool IsKeyJustReleased(Keys key)
    {
        return _currentKeyboardState.IsKeyUp(key) && _previousKeyboardState.IsKeyDown(key);
    }

    public bool IsKeyPressed(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key);
    }
}