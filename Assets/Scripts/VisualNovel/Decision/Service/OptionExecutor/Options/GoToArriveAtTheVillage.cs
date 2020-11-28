using UnityEngine.SceneManagement;

public class GoToArriveAtTheVillage: OptionExecutor
{
    private readonly TransitionService TransitionService = TransitionService.GetInstance();
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    
    protected override void Execute()
    {
        TransitionService.Save(TransitionIndexes.SequenceFromArriveAtTheVillage);
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromGoToVillage);
    
        SceneManager.LoadScene("Transition");
    }
}
