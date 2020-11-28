using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VisualNovelMenu : MonoBehaviour
{
    private Button NextButton;
    public static bool CanClickNext = true;

    private void Start()
    {
        NextButton = GameObject.FindGameObjectWithTag("NextButton").GetComponent<Button>();
        DecisionManager.HideDecision();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Return))
        {
            return;
        }
        
        NextButton.Select();
        NextButton.onClick.Invoke();
        StartCoroutine(Deselect());
    }

    public void OnClickNextSpeechButton()
    {
        if (CanClickNext)
        {
            VisualNovel.UpdateSpeech();
        }
    }

    private static IEnumerator Deselect()
    {
        yield return new WaitForSeconds(0.1f);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }
}
