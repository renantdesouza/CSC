using UnityEngine.SceneManagement;

public class GoToBrayanExplanation: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromGoToBrayanExplanation);
    
        SceneManager.LoadScene("VisualNovel");
    }
}
