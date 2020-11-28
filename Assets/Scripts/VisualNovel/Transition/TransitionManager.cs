using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private Transition Transition;
    private int CurrentSpeech;
    private int CurrentScene;
    private TransitionDataSaveOptions Data;
    private readonly TransitionService Service = TransitionService.GetInstance();

    private void Awake()
    {
        LoadSave();
        LoadTransition();
    }

    private void LoadSave()
    {
        Data = Service.LoadSave();
        CurrentScene = Data?.currentScene ?? 0;
        CurrentSpeech = 0;
    }

    private void SaveJson()
    {
        var index = CurrentScene + 1;
        Service.Save(index);
    }

    private void LoadTransition()
    {
        Transition = Service.LoadTransition();
    }

    private void Update()
    {
        if (Transition?.narratorsScenes == null)
        {
            return;
        }
        
        var countScenes = Transition.narratorsScenes.Count;
        var countSpeeches = 0;

        // What speech will be displayed.
        if (CurrentScene < countScenes)
        {
            var transitionScene = Transition.narratorsScenes[CurrentScene];

            if (transitionScene != null && transitionScene.speeches != null)
            {
                countSpeeches = transitionScene.speeches.Count;

                if (CurrentSpeech < countSpeeches)
                {
                    GameObject.FindGameObjectWithTag("NarratorsSpeech").GetComponent<Text>().text = transitionScene.speeches[CurrentSpeech];
                }
            }
        }

        // Increments the counter for current speech in scene.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (CurrentSpeech < countSpeeches)
            {
                CurrentSpeech++;
            }
        }
        
        if (CurrentSpeech != countSpeeches)
        {
            return;
        }
        
        SaveJson();

        // Goes to the next scene in the visual model mode.
        SceneManager.LoadScene("VisualNovel");
    }
}