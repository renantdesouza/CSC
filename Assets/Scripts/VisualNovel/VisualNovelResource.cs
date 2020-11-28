using System.IO;
using UnityEngine;
using Util;

public class VisualNovelResource: Resource<DialogueList>
{
    private const string VISUAL_NOVEL_PATH = "Assets/Resources/Data/VisualNovel";
    private const string VISUAL_NOVEL_SPRITES_PATH = "Sprites/Dialogue";

    private static VisualNovelResource _instance;

    private VisualNovelResource()
    {
    }

    public static VisualNovelResource GetInstance() => _instance ?? (_instance = new VisualNovelResource());
    
    public void SaveJson(DialogueDataSaveOptions data)
    {
        var path = Path.Combine(Application.dataPath, $"Data/VisualNovel/save.json");
        // Save($"{VISUAL_NOVEL_PATH}/save.json", data);
        Save(path, data);
    }

    public DialogueList LoadDialogueList()
    {
        var path = Path.Combine(Application.dataPath, $"Data/VisualNovel/speeches.json");

        // return Get($"{VISUAL_NOVEL_PATH}/speeches.json");
        return Get("Data/VisualNovel/speeches.json");
    }

    public DialogueDataSaveOptions LoadSave()
    {
        
        var path = Path.Combine(Application.dataPath, $"Data/VisualNovel/save.json");
        // return Get<DialogueDataSaveOptions>($"{VISUAL_NOVEL_PATH}/save.json");
        return Get<DialogueDataSaveOptions>("Data/VisualNovel/save.json");
    }

    public Sprite LoadSpriteByName(string name)
    {
        var path = Path.Combine(Application.dataPath, $"Data/VisualNovel/{name}");
        // return Resources.Load<Sprite>($"{VISUAL_NOVEL_SPRITES_PATH}/{name}");
        return Resources.Load<Sprite>($"Sprites/Dialogue/{name}");
    }
}