using UnityEngine.SceneManagement;

public class GoToDamnIt: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    private readonly TransitionService TransitionService = TransitionService.GetInstance();


    protected override void Execute()
    {
        TransitionService.Save(TransitionIndexes.SequenceFromDamnIt);
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromDamnIt);

        SceneManager.LoadScene("Transition");
    }
}