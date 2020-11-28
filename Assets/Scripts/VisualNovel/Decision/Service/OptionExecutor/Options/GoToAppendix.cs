using UnityEngine.SceneManagement;

public class GoToAppendix : OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();

    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromAppendix);

        SceneManager.LoadScene("VisualNovel");
    }
}
