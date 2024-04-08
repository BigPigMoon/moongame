using Microsoft.Xna.Framework;

namespace GameEngine.Components;

public class Transform2D
{
    /// <summary>
    /// Позиция объекта
    /// </summary>
    public Vector2 Translation = Vector2.Zero;
    /// <summary>
    /// Вращение объекта
    /// </summary>
    public float Rotation = 0;
    /// <summary>
    /// Размер объекта
    /// </summary>
    public Vector2 Scale = Vector2.One;
}