using UnityEngine.SceneManagement;

public class GoToSaveBoth : OptionExecutor
{
    private readonly TransitionService TransitionService = TransitionService.GetInstance();
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    private readonly BattleService BattleService = BattleService.GetInstance();
    
    protected override void Execute()
    {
        TransitionService.Save(TransitionIndexes.SequenceFromSaveBoth);
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromSaveBoth);
        BattleService.Save(BattleIndexes.SequenceFromSaveBoth);

        SceneManager.LoadScene("Transition");
    }
}