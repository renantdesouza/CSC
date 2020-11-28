public class SoundEventCaller : EventCaller
{
    private static string _jsonName;

    protected override void Execute()
    {
    }

    public static string Get_jsonName()
    {
        return _jsonName;
    }

    public static void Set_jsonName(string jsonName)
    {
        _jsonName = jsonName;
    }

    protected override void SetJsonName(string jsonName)
    {
        _jsonName = jsonName;
    }
}