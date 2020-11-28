using UnityEngine.SceneManagement;

public class GoToFool: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromTolo);
        
        SceneManager.LoadScene("VisualNovel");
    }
}