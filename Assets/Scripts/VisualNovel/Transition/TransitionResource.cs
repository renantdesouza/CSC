using Util;

public class TransitionResource : Resource<Transition>
{
    private const string TransitionDataPath = "Assets/Resources/Data/VisualNovel/Transition";
    
    private static TransitionResource _instance;
    
    private TransitionResource()
    {
    }

    public static TransitionResource GetInstance() => _instance ?? (_instance = new TransitionResource());

    public TransitionDataSaveOptions LoadSave()
    {
        return Get<TransitionDataSaveOptions>($"{TransitionDataPath}/save.json");
    }

    public void Save(TransitionDataSaveOptions data)
    {
        Save($"{TransitionDataPath}/save.json", data);
    }

    public Transition LoadTransition()
    {
        return Get($"{TransitionDataPath}/transition.json");
    }
}