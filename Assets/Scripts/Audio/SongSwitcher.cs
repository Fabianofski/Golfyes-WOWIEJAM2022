using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Audio
{
    public class SongSwitcher : MonoBehaviour
    {

        [SerializeField] private Sound track;
        [SerializeField] private SoundEvent switchMusicTrack;
        
        private void Start()
        {
            switchMusicTrack.Raise(track);
        }
    }
}