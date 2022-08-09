using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace F4B1.UI
{
    public class AudioSlider : MonoBehaviour
    {

        [SerializeField] private AudioMixer mixer;
        private AudioSource _previewSource;

        private void Start()
        {
            _previewSource = GetComponentInChildren<AudioSource>();
        }

        public void SetMixerVolume(float volume)
        {
            PlayerPrefs.SetFloat(mixer.name, volume);
            PlayerPrefs.Save();
            
            volume = Mathf.Log(volume) * 20;
            mixer.SetFloat("volume", volume);
            
            if(_previewSource) _previewSource.Play();
        }
        
    }
}
