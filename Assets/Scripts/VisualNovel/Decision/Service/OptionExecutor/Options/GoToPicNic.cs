using UnityEngine.SceneManagement;

public class GoToPicNic: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    private readonly TransitionService TransitionService = TransitionService.GetInstance();
    
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromPicNic);
        TransitionService.Save(TransitionIndexes.SequenceFromPicNic);

        SceneManager.LoadScene("Transition");
    }
}
