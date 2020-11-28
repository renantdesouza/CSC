using UnityEngine.SceneManagement;

public class GoToWhatHappened : OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();

    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromWhatHappened);

        SceneManager.LoadScene("VisualNovel");
    }
}