using System;
using F4B1.Audio;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Variable of type `F4B1.Audio.Sound`. Inherits from `AtomVariable&lt;F4B1.Audio.Sound, SoundPair, SoundEvent,
    ///     SoundPairEvent, SoundSoundFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/Sound", fileName = "SoundVariable")]
    public sealed class SoundVariable : AtomVariable<Sound, SoundPair, SoundEvent, SoundPairEvent, SoundSoundFunction>
    {
        protected override bool ValueEquals(Sound other)
        {
            throw new NotImplementedException();
        }
    }
}