public class GoToEventCaller : EventCaller
{
    private static string _option;
    
    protected override void Execute()
    {
        OptionExecutor.Execute(_option);
    }

    protected override void SetJsonName(string option)
    {
        _option = option;
    }
}