using BackgroundSound;
using UnityEngine.SceneManagement;

public class GoToIsNecessary: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromIsNecessary);
        
        BackgroundSoundManager.Play("Aventura");
        
        SceneManager.LoadScene("VisualNovel");
    }
}