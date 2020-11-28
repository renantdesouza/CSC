using UnityEngine.SceneManagement;

public class GoToIsNotMyProblem: OptionExecutor
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    protected override void Execute()
    {
        VisualNovelService.Save(VisualNovelIndexes.SequenceFromIsNotMyProblem);

        SceneManager.LoadScene("VisualNovel");
    }
}