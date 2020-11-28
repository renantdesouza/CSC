using UnityEngine.SceneManagement;

public class GoToYouAreRight: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromYouAreRight);

        SceneManager.LoadScene("VisualNovel");
    }
}