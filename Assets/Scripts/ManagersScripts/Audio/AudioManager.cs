using System.Collections.Generic;
using UnityEngine;

namespace ManagersScripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        #region Singleton

        private static AudioManager _instance;
        public static AudioManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                DontDestroyOnLoad(gameObject);
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        #endregion

        [SerializeField] private AudioSource bgmAudioSource;
        [SerializeField] private AudioSource sfxAudioSource;
        [SerializeField] private AudioSource introAudioSource;
        [SerializeField] private AudioSource ambientAudioSource;
        
        [SerializeField] private List<AudioClip> bgmAudioClip = new List<AudioClip>();
        [SerializeField] private List<AudioClip> sfxAudioClip = new List<AudioClip>();
        [SerializeField] private List<AudioClip> introAudioClip = new List<AudioClip>();
        [SerializeField] private List<AudioClip> ambientAudioClip = new List<AudioClip>();

        public float introLength;

        public void PlayBGM(int index)
        {
            bgmAudioSource.clip = bgmAudioClip[index];
            bgmAudioSource.Play();
        }
        
        public void PlayBGM(string clipName)
        {
            int index = bgmAudioClip.FindIndex(i => i.name == clipName);
            bgmAudioSource.clip = bgmAudioClip[index];
            bgmAudioSource.Play();
        }
        
        public void PlaySFX(int index)
        {
            sfxAudioSource.PlayOneShot(sfxAudioClip[index]);
        }
        
        public void PlaySFX(string clipName)
        {
            int index = sfxAudioClip.FindIndex(i => i.name == clipName);
            sfxAudioSource.PlayOneShot(sfxAudioClip[index]);
            Debug.Log(clipName);
        }
        
        public void PlayIntroBGM(int index)
        {
            introAudioSource.clip = introAudioClip[index];
            introAudioSource.Play();
        }
        
        public void PlayIntroBGM(string clipName)
        {
            int index = introAudioClip.FindIndex(i => i.name == clipName);
            introAudioSource.clip = introAudioClip[index];
            introAudioSource.Play();

            introLength = introAudioSource.clip.length;
        }
        
        public void PlayAmbient(int index)
        {
            ambientAudioSource.clip = ambientAudioClip[index];
            ambientAudioSource.Play();
        }
        
        public void PlayAmbient(string clipName)
        {
            int index = ambientAudioClip.FindIndex(i => i.name == clipName);
            ambientAudioSource.clip = ambientAudioClip[index];
            ambientAudioSource.Play();
        }
        
        public void StopAllMusic()
        {
            bgmAudioSource.Stop();
            sfxAudioSource.Stop();
            introAudioSource.Stop();
            ambientAudioSource.Stop();
        }
    }
}