using BackgroundSound;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private void Awake()
    {
        BackgroundSoundManager.Stop();
    }

    public void OnClickReset()
    {
        SceneManager.LoadScene("MainMenu");
    }
}


/*
 *
 *
 *
 *
 * IEnumerator loadStreamingAsset(string fileName)
{
    string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

    string result;
    if (filePath.Contains("://") || filePath.Contains(":///"))
    {
        WWW www = new WWW(filePath);
        yield return www;
        result = www.text;
    }
    else
        result = System.IO.File.ReadAllText(filePath);
}
 */