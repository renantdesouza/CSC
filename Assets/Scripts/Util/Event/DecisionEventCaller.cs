public class DecisionEventCaller : EventCaller
{
    private static int _index;
    private static int _lastIndex = -1;
    
    protected override void Execute()
    {
        if (_index == _lastIndex)
        {
            return;
        }
        
        _lastIndex = _index;
        
        DecisionManager.ShowDecision(_index);
    }

    protected override void SetJsonName(string jsonName)
    {
        _index = 0;
        int.TryParse(jsonName, out _index);
    }
}
