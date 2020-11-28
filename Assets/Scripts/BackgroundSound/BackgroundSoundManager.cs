using UnityEngine;

namespace BackgroundSound
{
    public class BackgroundSoundManager: MonoBehaviour
    {
        private static AudioSource _source;
        private static AudioClip _sound;
        
        private static AudioClip _audioClip;

        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            _source = GetComponent<AudioSource>();
        }

        public static void Play(string name)
        {
            if (_source.isPlaying)
            {
                _source.Stop();
            }
            
            var audioClip = BackgroundSoundResource.GetInstance().GetAudioClip(name);
            
            _source.clip = audioClip;
            _source.loop = true;
            _source.Play();
        }

        public static void Stop()
        {
            _source.Stop();
        }
    }
}