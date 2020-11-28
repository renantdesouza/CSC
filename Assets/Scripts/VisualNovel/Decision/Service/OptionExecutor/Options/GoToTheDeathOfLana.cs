using UnityEngine.SceneManagement;

public class GoToTheDeathOfLana: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromTheDeathOfLana);
        
        SceneManager.LoadScene("VisualNovel");
    }
}