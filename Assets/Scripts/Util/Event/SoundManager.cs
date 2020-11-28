using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource Source;

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var soundName = SoundEventCaller.Get_jsonName();

        if (string.IsNullOrEmpty(soundName))
        {
            return;
        }

        Source.PlayOneShot(Resources.Load<AudioClip>($"Sound/{soundName}"));
        SoundEventCaller.Set_jsonName(null);
    }
}
