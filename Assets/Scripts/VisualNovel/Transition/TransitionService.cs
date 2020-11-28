public class TransitionService
{
    private static TransitionService _instance;

    private readonly TransitionResource Resource;

    private TransitionService()
    {
        Resource = TransitionResource.GetInstance();
    }

    public static TransitionService GetInstance() => _instance ?? (_instance = new TransitionService());

    public TransitionDataSaveOptions LoadSave()
    {
        return Resource.LoadSave();
    }

    public Transition LoadTransition()
    {
        return Resource.LoadTransition();
    }

    public void Save(int index)
    {
        var data = new TransitionDataSaveOptions()
        {
            currentScene = index
        };
        
        Resource.Save(data);
    }
}