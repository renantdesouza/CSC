using UnityEngine.SceneManagement;

public class GoToYesItWouldHaveBeen: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromYesItWouldHaveBeen);
        
        SceneManager.LoadScene("VisualNovel");
    }
}