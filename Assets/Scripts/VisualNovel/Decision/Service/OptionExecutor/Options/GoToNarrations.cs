using UnityEngine.SceneManagement;

public class GoToNarrations: OptionExecutor
{
    private readonly TransitionService TransitionService = TransitionService.GetInstance();
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    
    protected override void Execute()
    {
        TransitionService.Save(TransitionIndexes.SequenceFromPicNic);
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromPicNic);
        
        SceneManager.LoadScene("Transition");
    }
}