using UnityEngine;

namespace BackgroundSound
{
    public class BackgroundSoundResource
    {
        private const string Path = "Sound/";
        
        private static BackgroundSoundResource _instance;

        private BackgroundSoundResource()
        {
        }

        public static BackgroundSoundResource GetInstance() => _instance ?? (_instance = new BackgroundSoundResource());

        public AudioClip GetAudioClip(string name)
        {
            return Resources.Load<AudioClip>($"{Path}{name}");
        }
    }
}