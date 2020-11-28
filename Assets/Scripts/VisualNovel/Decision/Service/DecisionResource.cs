using Util;

public class DecisionResource: Resource<DecisionScene>
{
    private const string DecisionPath = "Assets/Resources/Data/VisualNovel/Decision";

    private static DecisionResource _instance;

    public static DecisionResource GetInstance() => _instance ?? (_instance = new DecisionResource());
    
    public DecisionScene LoadDecisionScenes()
    {
        return Get($"{DecisionPath}/decision.json");
    }

    public void Save(DecisionSave data)
    {
        Save($"{DecisionPath}/save.json", data);
    }

    public DecisionSave LoadSave()
    {
        return Get<DecisionSave>($"{DecisionPath}/save.json");
    }
}
