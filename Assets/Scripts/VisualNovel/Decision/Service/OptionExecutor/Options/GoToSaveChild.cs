using UnityEngine.SceneManagement;

public class GoToSaveChild : OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromSaveChild);
        
        SceneManager.LoadScene("VisualNovel");
    }
}