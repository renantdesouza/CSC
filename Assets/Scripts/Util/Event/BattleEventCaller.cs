using UnityEngine.SceneManagement;

public class BattleEventCaller : EventCaller
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();

    protected override void Execute()
    {
        VisualNovel.UpdateSpeech();
        var index = VisualNovel.GetCurrentSpeechIndex();
        VisualNovelService.Save(index);
        
        SceneManager.LoadScene("TurnBattle");
    }

    protected override void SetJsonName(string jsonName) {}
}
