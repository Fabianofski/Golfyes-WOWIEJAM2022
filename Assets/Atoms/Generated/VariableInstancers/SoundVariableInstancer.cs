using F4B1.Audio;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Variable Instancer of type `F4B1.Audio.Sound`. Inherits from `AtomVariableInstancer&lt;SoundVariable, SoundPair,
    ///     F4B1.Audio.Sound, SoundEvent, SoundPairEvent, SoundSoundFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/Sound Variable Instancer")]
    public class SoundVariableInstancer : AtomVariableInstancer<
        SoundVariable,
        SoundPair,
        Sound,
        SoundEvent,
        SoundPairEvent,
        SoundSoundFunction>
    {
    }
}