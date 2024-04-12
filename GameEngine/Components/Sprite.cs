using Microsoft.Xna.Framework;

namespace GameEngine.Components;

public class Sprite
{
    /// <summary>
    /// Цветовой оттенок спрайта
    /// </summary>
    public Color Color = Color.White;
    /// <summary>
    /// Отзеркаливание по горизонтале
    /// </summary>
    public bool FlipX = false;
    /// <summary>
    /// Отзеркаливание по вертикале
    /// </summary>
    public bool FlipY = false;

    /// <summary>
    /// Участок спрайта внутри изоображения
    /// </summary>
    public Rectangle Rect = Rectangle.Empty;

    /// <summary>
    /// Точка относительно которой будут происходить преобразования (перемещение, вращение)
    /// </summary>
    public Anchor Anchor = Anchor.Center;
    
    public Vector2 Origin { get; private set; }

    public Sprite()
    {
    }
}