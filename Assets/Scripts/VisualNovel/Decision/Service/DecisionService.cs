public class DecisionService
{
    private static DecisionService _instance;
    
    private readonly DecisionResource Resource;
    
    private DecisionService()
    {
        Resource = DecisionResource.GetInstance();
    }

    public static DecisionService GetInstance() => _instance ?? (_instance = new DecisionService());

    public DecisionScene LoadDecisionScene()
    {
        return Resource.LoadDecisionScenes();
    }

    public void Save(int index)
    {
        var data = new DecisionSave() {currentDecision = index};
        
        Resource.Save(data);
    }

    public DecisionSave LoadSave()
    {
        return Resource.LoadSave();
    }
}