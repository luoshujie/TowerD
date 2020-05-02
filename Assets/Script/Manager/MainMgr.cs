using System;
using UnityEngine;

namespace Script.Manager
{
    public class MainMgr : MonoBehaviour
    {
        public static MainMgr instance;
        public AudioSource audioSource;

        public AudioClip[] backGroupAudioList;

        public AudioClip openWindowAudio;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void PlayBackGroupAudio(int index)
        {
            audioSource.Stop();
            audioSource.clip = backGroupAudioList[index];
            audioSource.Play();
        }

        public void PlayOpenWindowAudio()
        {
            audioSource.PlayOneShot(openWindowAudio);
        }

        public bool SetAudioState()
        {
            if (audioSource.volume>0)
            {
                audioSource.volume = 0;
            }
            else
            {
                audioSource.volume = 1;
            }

            return GetBackGroupState();
        }
        
        public bool GetBackGroupState()
        {
            return audioSource.volume > 0;
        }
    }
}