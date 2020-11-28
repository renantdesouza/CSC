using BackgroundSound;
using UnityEngine.SceneManagement;

public class GoToVillage: OptionExecutor
{
    private readonly TransitionService TransitionService = TransitionService.GetInstance();
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();

    protected override void Execute()
    {
        TransitionService.Save(TransitionIndexes.SequenceFromGoToVillage);
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromGoToVillage);
        
        BackgroundSoundManager.Play("Tranquila");
        
        SceneManager.LoadScene("Transition");
    }
}
