namespace GameEngine.Components.TimeUtils;

public class StopwatchComponent
{
    /// <summary>
    /// Прошедшее время
    /// </summary>
    public float Elapsed { get; set; }
    
    /// <summary>
    /// Секундомер на паузе?
    /// </summary>
    public bool IsPaused { get; private set; }

    /// <summary>
    /// Обновить секундомер
    /// </summary>
    /// <param name="delta">Время кадра</param>
    public void Tick(float delta)
    {
        if (!IsPaused)
        {
            Elapsed += delta;
        }
    }
    
    /// <summary>
    /// Сбросить секундомер
    /// </summary>
    public void Reset() => Elapsed = 0f;

    /// <summary>
    /// Остановить секундомер
    /// </summary>
    public void Pause() => IsPaused = true;

    /// <summary>
    /// Возобновить секундомер
    /// </summary>
    public void Unpause() => IsPaused = false;
}