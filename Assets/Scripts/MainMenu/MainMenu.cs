using Hero;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private readonly VisualNovelService VisualNovelService = VisualNovelService.GetInstance();
    private readonly TransitionService TransitionService = TransitionService.GetInstance();
    private readonly DecisionService DecisionService = DecisionService.GetInstance();
    private readonly BattleService BattleService = BattleService.GetInstance();
    private readonly HeroService HeroService = HeroService.GetInstance();
    
    // buttons present in the scene.
    private Button[] Buttons;
    private int LastButtonIndex;
    private int ActiveButtonIndex;

    // will start a new game.
    public void OnClickNewGame()
    {
        VisualNovelService.Save(0);
        TransitionService.Save(0);
        DecisionService.Save(0);
        BattleService.Save(0);

        BattleService.Reinitialize();
        HeroService.Reinitialize();

        SceneManager.LoadScene("VisualNovel");
    }

    // TODO ADICIONAR BOTÃO DE LOAD
    public void LoadGame()
    {
        SceneManager.LoadScene("VisualNovel");
    }

    // will quit the game.
    public void OnClickQuit()
    {
        Application.OpenURL("http://pudim.com.br/");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        # else
        Application.Quit();
        # endif
    }

    // will run on start.
    private void Start()
    {
        Buttons = (Button[]) FindObjectsOfType(typeof(Button));
        LastButtonIndex = Buttons.Length - 1;
    }

    // will run every render looping and testing input actions.
    private void Update()
    {
        var mustSelect = false;


        // clicking ESC exits the game.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickQuit();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (ActiveButtonIndex <= 0)
            {
                ActiveButtonIndex = LastButtonIndex;
            }
            else
            {
                ActiveButtonIndex--;
            }

            mustSelect = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (ActiveButtonIndex == LastButtonIndex)
            {
                ActiveButtonIndex = 0;
            }
            else
            {
                ActiveButtonIndex++;
            }

            mustSelect = true;
        }

        // verify if button can be selected.
        if (mustSelect)
        {
            // clicking on enter when button is selected executes the respective option.
            Buttons[ActiveButtonIndex].Select();
        }
    }
}
