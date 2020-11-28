using UnityEngine.SceneManagement;

public class GoToVillageMenu: OptionExecutor
{
    protected override void Execute()
    {
        SceneManager.LoadScene("Village");
    }
}