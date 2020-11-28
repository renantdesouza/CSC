using UnityEngine.SceneManagement;

public class GoToMaluExplanation: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromMaluExplanation);
        
        SceneManager.LoadScene("VisualNovel");
    }
}