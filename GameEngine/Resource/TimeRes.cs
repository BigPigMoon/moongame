namespace GameEngine.Resource;

public class TimeRes
{
    public float DeltaTime { get; set; }
    
    private static TimeRes? _instance;
    
    private TimeRes() { }

    public static TimeRes Instance => _instance ??= new TimeRes();
}