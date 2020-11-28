using UnityEngine.SceneManagement;

public class GoToDoNotWorry : OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();

    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromDoNotWorry);

        SceneManager.LoadScene("VisualNovel");
    }
}