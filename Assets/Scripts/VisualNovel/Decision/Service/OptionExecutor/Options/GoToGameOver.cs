using UnityEngine.SceneManagement;

public class GoToGameOver: OptionExecutor
{
    protected override void Execute()
    {
        SceneManager.LoadScene("GameOver");
    }
}
