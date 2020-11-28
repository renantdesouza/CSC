using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class DecisionManager : MonoBehaviour
{
    private static int _currentDecision;
    private static DecisionScene _decisionScene;
    private static string _decisionName;
    private static List<DecisionViewService.OptionButton> _optionButtons;
    private static readonly DecisionService Service = DecisionService.GetInstance();

    private void Awake()
    {
        _currentDecision = Service.LoadSave().currentDecision;
    }

    private static void LoadDecisions()
    {
        _decisionScene = DecisionService.GetInstance().LoadDecisionScene();
        
        var count = _decisionScene.decisions[_currentDecision].options.Count;

        var dvs = DecisionViewService.GetInstance();
        
        _decisionName = dvs.GetDecisionName(count);
        _optionButtons = dvs.GetButtonsName(count);
    }

    public static void HideDecision()
    {
        GameObject.FindGameObjectWithTag("Decision_1").transform.localScale = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("Decision_2").transform.localScale = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("Decision_3").transform.localScale = new Vector3(0, 0, 0);
    }

    public static void ShowDecision(int index)
    {
        _currentDecision = index;

        LoadDecisions();

        var decision = _decisionScene.decisions[_currentDecision];
        var options = decision.options;
        
        GameObject.FindGameObjectWithTag(_decisionName).transform.localScale = new Vector3(1,1,1);
        
        VisualNovelMenu.CanClickNext = false;

        var counter = 0;
        
        while (counter < options.Count)
        {
            var optionData = options[counter];
            var optionButton = _optionButtons[counter];
            
            var textTag = $"{optionButton.TextTag}_{_optionButtons.Count}";
            GameObject.FindGameObjectWithTag(textTag).GetComponent<Text>().text = optionData.key;
            
            var buttonTag = $"{optionButton.ButtonTag}_{_optionButtons.Count}";
            GameObject.FindGameObjectWithTag(buttonTag).GetComponent<Button>().onClick.AddListener(() => {
                OptionExecutor.Execute(optionData.action);
                VisualNovelMenu.CanClickNext = true;
                HideDecision();
            });

            counter++;
        }

        UpdateDecisionIndex();
        
        Service.Save(_currentDecision);
    }
    
    private static void UpdateDecisionIndex()
    {
        if (_currentDecision + 1 == _decisionScene.decisions.Count)
        {
            return;
        }

        _currentDecision++;
    }
}
