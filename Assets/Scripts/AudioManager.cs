using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace HackedDesign
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [Header("SFX")]
        [SerializeField] private AudioSource warningSFX;
        [SerializeField] private AudioSource coolantSFX;
        [SerializeField] private AudioSource pickupSFX;
        [SerializeField] private AudioSource testSFX;
        [Header("Music")]
        [SerializeField] private AudioSource menuMusic;
        [SerializeField] private AudioSource introMusic;
        [SerializeField] private AudioSource incomingMusic;
        [SerializeField] private AudioSource attackMusic;
        [SerializeField] private AudioSource intermissionMusic;

        public static AudioManager Instance { get; private set; }

        AudioManager()
        {
            Instance = this;
        }

        public void SetMasterVolume(float value)
        {
            mixer.SetFloat("Master", Mathf.Log10(value) * 20);
        }

        public void SetSFXVolume(float value)
        {
            mixer.SetFloat("SFX", Mathf.Log10(value) * 20);
            PlayTest();
        }

        public void SetMusicVolume(float value)
        {
            mixer.SetFloat("Music", Mathf.Log10(value) * 20);
        }

        public void PlayWarning()
        {
            if (warningSFX != null && !warningSFX.isPlaying)
            {
                warningSFX.Play();
            }
        }

        public void PlayCoolant()
        {
            if (coolantSFX != null && !coolantSFX.isPlaying)
            {
                coolantSFX.Play();
            }
        }

        public void PlayPickup()
        {
            if (pickupSFX != null && !pickupSFX.isPlaying)
            {
                pickupSFX.Play();
            }
        }

        public void PlayTest()
        {
            if (testSFX != null)
            {
                testSFX.Play();
            }
        }

        public void PlayMenuMusic()
        {
            if (menuMusic != null)
            {
                menuMusic.Play();
            }
        }

        public void StopMenuMusic()
        {
            if (menuMusic != null)
            {
                menuMusic.Stop();
            }
        }

        public void PlayIntroMusic()
        {
            introMusic?.Play();
        }

        public void StopIntroMusic()
        {
            introMusic?.Stop();
        }

        public void PlayIncomingMusic()
        {
            if (incomingMusic != null && !incomingMusic.isPlaying)
            {
                incomingMusic?.Play();
            }
        }

        public void StopIncomingMusic()
        {
            incomingMusic?.Stop();
        }

        public void PlayAttackMusic()
        {
            if (attackMusic != null && !attackMusic.isPlaying)
            {
                attackMusic?.Play();
            }
        }

        public void StopAttackMusic()
        {
            attackMusic?.Stop();
        }        

        public void PlayIntermissionMusic()
        {
            if (intermissionMusic != null && !intermissionMusic.isPlaying)
            {
                intermissionMusic?.Play();
            }
        }

        public void StopIntermissionMusic()
        {
            intermissionMusic?.Stop();
        }            
    }
}