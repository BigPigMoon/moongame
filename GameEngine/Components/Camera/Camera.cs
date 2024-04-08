namespace GameEngine.Components.Camera;

/// <summary>
/// Компонент камеры
///
/// Если камер несколько ими можно управлять с помощью перменной IsActive
/// </summary>
public class Camera
{
    /// <summary>
    /// Переменная отвечающая за активность камеры
    /// </summary>
    public bool IsActive { get; set; } = true;
}