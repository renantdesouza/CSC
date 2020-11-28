using UnityEngine.SceneManagement;

public class GoToReproach : OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromReproachLane);
        
        SceneManager.LoadScene("VisualNovel");
    }
}
