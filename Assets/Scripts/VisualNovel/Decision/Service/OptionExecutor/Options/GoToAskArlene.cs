using UnityEngine.SceneManagement;

public class GoToAskArlene : OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromAskArlene);
        
        SceneManager.LoadScene("VisualNovel");
    }
}