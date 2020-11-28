using UnityEngine.SceneManagement;

public class GoToSorry: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromSorry);
        
        SceneManager.LoadScene("VisualNovel");
    }
}