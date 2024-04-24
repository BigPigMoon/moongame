using Arch.Core;
using GameEngine.Components;
using GameEngine.Components.TimeUtils;
using GameEngine.Resource;
using GameEngine.SystemEvent;

namespace GameEngine.Plugins;

public class TimerPlugin : IPlugin
{
    public void Create(App app)
    {
        app.AddSystem<OnUpdate, TickTimers>();
        app.AddSystem<OnUpdate, TickStopwatch>();
    }
}

public class TickStopwatch : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<StopwatchComponent>();
    
    public void Run(World world)
    {
        world.Query(in _description, (ref StopwatchComponent stopwatch) =>
        {
            var dt = TimeRes.Instance.DeltaTime;
            
            stopwatch.Tick(dt);
        });
    }
}

public class TickTimers : ISystem
{
    private readonly QueryDescription _description = new QueryDescription().WithAll<TimerComponent>();
    
    public void Run(World world)
    {
        world.Query(in _description, (ref TimerComponent timer) =>
        {
            var dt = TimeRes.Instance.DeltaTime;
            
            timer.Tick(dt);
        });
    }
}