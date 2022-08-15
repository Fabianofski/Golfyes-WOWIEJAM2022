using System.Security.Cryptography;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Audio
{
    public class AudioManager : MonoBehaviour
    {

        [SerializeField] private VoidEvent destroySoundEvent;
        
        public void PlaySound(Sound sound)
        {
            GameObject audioObject = new GameObject(){ name = sound.clip.name};
            if (sound.dontDestroyOnLoad) DontDestroyOnLoad(audioObject);
            AudioSource source = audioObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.outputAudioMixerGroup = sound.outputAudioMixerGroup;
            if (sound.randomlyPitchSound)
                source.pitch = Random.Range(sound.pitchBounds.x, sound.pitchBounds.y);
            if (sound.destroySoundOnEvent) destroySoundEvent.Register( () => Destroy(audioObject));
            source.volume = sound.volume;
            source.clip = sound.clip;
            source.Play();
            Destroy(audioObject, sound.clip.length * 2f);
        }
        
    }
}
