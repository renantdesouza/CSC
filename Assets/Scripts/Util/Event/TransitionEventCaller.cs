using UnityEngine.SceneManagement;

public class TransitionEventCaller : EventCaller
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();

    protected override void Execute()
    {
        VisualNovel.UpdateSpeech();
        var index = VisualNovel.GetCurrentSpeechIndex();
        VisualNovelService.Save(index);
        
        SceneManager.LoadScene("Transition");
    }

    protected override void SetJsonName(string jsonName) { }
}
