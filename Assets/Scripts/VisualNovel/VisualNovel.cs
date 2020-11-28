using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using BackgroundSound;

public class VisualNovel : MonoBehaviour
{
    private static int _currentSpeech;
    private static DialogueList _dialogues;

    private readonly VisualNovelService Service = VisualNovelService.GetInstance();
    private int LastCurrentSpeech;
    private List<Speech> Speeches;
    private DialogueDataSaveOptions Data;
    private Image BackgroundImage;
    private Image SpeakerImage;
    private Text SpeakerText;
    private Text SpeakerName;
    
    public static int GetCurrentSpeechIndex()
    {
        return _currentSpeech;
    }

    private void Awake()
    {
        SpeakerName = GameObject.FindGameObjectWithTag("SpeakerName").GetComponent<Text>();
        SpeakerText = GameObject.FindGameObjectWithTag("SpeechText").GetComponent<Text>();
        SpeakerImage = GameObject.FindGameObjectWithTag("SpeakerImage").GetComponent<Image>();
        BackgroundImage = GameObject.FindGameObjectWithTag("Background").GetComponent<Image>();
        
        Data = Service.LoadSave(); 
        
        _currentSpeech = Data.currentSpeech;
        LastCurrentSpeech = _currentSpeech - 1;
        
        _dialogues = Service.LoadDialogueList();
    }

    private void Update()
    {
        var mPath = Application.dataPath;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + mPath);
        
        if (_currentSpeech <= LastCurrentSpeech)
        {
            return;
        }
        
        LastCurrentSpeech = _currentSpeech;
        
        var speech = _dialogues.speeches[_currentSpeech];
        
        BackgroundImage.sprite = Service.LoadSpriteByName(speech.background);
        SpeakerImage.sprite = Service.LoadSpriteByName(speech.speaker.portrait);
        SpeakerText.text = speech.value;
        SpeakerName.text = speech.speaker.name;

        if (speech.backgroundSound != null && !speech.backgroundSound.Equals(""))
        {
            BackgroundSoundManager.Play(speech.backgroundSound);
        }

        if (speech.@event.type == null || speech.@event.value == null)
        {
            return;
        }
        
        Service.Save(_currentSpeech);
            
        EventCaller.CallEvent(speech.@event.type, speech.@event.value);
    }

    public static void UpdateSpeech()
    {
        if (_currentSpeech < _dialogues.speeches.Count - 1)
        {
            _currentSpeech += 1;
        }
    }
}