using System.Collections.Generic;

public abstract class EventCaller
{
    private static readonly Dictionary<string, EventCaller> EventCallers = new Dictionary<string, EventCaller>()
    {
        { EventType.Battle, new BattleEventCaller() },
        { EventType.Decision, new DecisionEventCaller() },
        { EventType.Sound, new SoundEventCaller() },
        { EventType.Transition, new TransitionEventCaller() },
        { EventType.GoTo, new GoToEventCaller()}
        
    };

    public static void CallEvent(string eventType, string eventParameter)
    {
        var dict = EventCallers[eventType];
        
        dict?.SetJsonName(eventParameter);
        
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        dict?.Execute();
    }

    protected abstract void SetJsonName(string jsonName);

    protected abstract void Execute();

}