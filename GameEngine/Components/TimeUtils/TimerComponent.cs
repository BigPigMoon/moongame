namespace GameEngine.Components.TimeUtils;

public class TimerComponent(float duration, TimerMode timerMode)
{
    /// <summary>
    /// Время таймера в секундах
    /// </summary>
    public float Duration { get; set; } = duration;

    /// <summary>
    /// Режим таймера
    /// </summary>
    /// <seealso cref="TimerMode"/>
    public TimerMode Mode
    {
        get => timerMode;
        set
        {
            if (timerMode != TimerMode.Repeating && value == TimerMode.Repeating && IsFinished)
            {
                _stopwatch.Reset();
                IsFinished = IsJustFinished();
            }
            timerMode = value;
        }
    }

    /// <summary>
    /// Таймер закончил?
    /// </summary>
    public bool IsFinished { get; private set; }
    
    /// <summary>
    /// Таймер остановлен?
    /// </summary>
    public bool IsPaused => _stopwatch.IsPaused;
    
    /// <summary>
    /// Количество срабатываний таймера за кадр
    /// </summary>
    public uint TimesFinishedThisTick { get; private set; }
    
    /// <summary>
    /// Секундомер
    /// </summary>
    private readonly StopwatchComponent _stopwatch = new();

    /// <summary>
    /// Таймер только что закончил?
    /// </summary>
    /// <returns></returns>
    public bool IsJustFinished() => TimesFinishedThisTick > 0;

    /// <summary>
    /// Обновить таймер, а точнее его внутренний секундомер
    /// </summary>
    /// <param name="delta">Время кадра</param>
    /// <seealso cref="_stopwatch"/>
    public void Tick(float delta)
    {
        if (IsPaused)
        {
            TimesFinishedThisTick = 0;
            if (Mode == TimerMode.Repeating)
            {
                IsFinished = false;
            }
            return;
        }

        if (Mode != TimerMode.Repeating && IsFinished)
        {
            TimesFinishedThisTick = 0;
            return;
        }
        
        _stopwatch.Tick(delta);
        IsFinished = _stopwatch.Elapsed >= Duration;

        if (IsFinished)
        {
            if (Mode == TimerMode.Repeating)
            {
                TimesFinishedThisTick = (uint)(_stopwatch.Elapsed / Duration);
                _stopwatch.Elapsed = MathF.IEEERemainder(_stopwatch.Elapsed, Duration);
            }
            else
            {
                TimesFinishedThisTick = 1;
                _stopwatch.Elapsed = Duration;
            }
        }
        else
        {
            TimesFinishedThisTick = 0;
        }
    }

    /// <summary>
    /// Обновить таймер
    /// </summary>
    public void Reset()
    {
        _stopwatch.Reset();
        IsFinished = false;
    }
    
    /// <summary>
    /// Остановить таймер
    /// </summary>
    public void Pause()
    {
        _stopwatch.Pause();
    }

    /// <summary>
    /// Возвобновить таймер
    /// </summary>
    public void Unpause()
    {
        _stopwatch.Unpause();
    }
}
