using UnityEngine.SceneManagement;

public class GoToObserveChoice : OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    private readonly TransitionService TransitionService = TransitionService.GetInstance();
    
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromObserve);
        TransitionService.Save(TransitionIndexes.SequenceFromObserve);
        
        SceneManager.LoadScene("Transition");
    }
}