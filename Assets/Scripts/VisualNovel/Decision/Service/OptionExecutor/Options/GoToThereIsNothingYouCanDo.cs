using BackgroundSound;
using UnityEngine.SceneManagement;

public class GoToThereIsNothingYouCanDo: OptionExecutor
{
    private VisualNovelService VisualNovelService = VisualNovelService.GetInstance();

    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromThereIsNothingYouCanDo);
        
        BackgroundSoundManager.Play("Aventura");

        SceneManager.LoadScene("VisualNovel");
    }
}