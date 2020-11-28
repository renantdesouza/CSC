using UnityEngine;

public class VisualNovelService
{
    private static VisualNovelService _instance;
    
    private readonly VisualNovelResource Resource;

    private VisualNovelService()
    {
        Resource = VisualNovelResource.GetInstance();
    }

    public static VisualNovelService GetInstance() => _instance ?? (_instance = new VisualNovelService());

    public void Save(int index)
    {
        var data = new DialogueDataSaveOptions
        {
            currentSpeech = index
        };
        
        Resource.SaveJson(data);
    }
    
    public DialogueList LoadDialogueList()
    {
        return Resource.LoadDialogueList();
    }

    public DialogueDataSaveOptions LoadSave()
    {
        return Resource.LoadSave();
    }

    public Sprite LoadSpriteByName(string name)
    {
        return Resource.LoadSpriteByName(name);
    }
}