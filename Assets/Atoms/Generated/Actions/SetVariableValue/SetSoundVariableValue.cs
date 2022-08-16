using F4B1.Audio;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Set variable value Action of type `F4B1.Audio.Sound`. Inherits from `SetVariableValue&lt;F4B1.Audio.Sound,
    ///     SoundPair, SoundVariable, SoundConstant, SoundReference, SoundEvent, SoundPairEvent, SoundVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/Sound", fileName = "SetSoundVariableValue")]
    public sealed class SetSoundVariableValue : SetVariableValue<
        Sound,
        SoundPair,
        SoundVariable,
        SoundConstant,
        SoundReference,
        SoundEvent,
        SoundPairEvent,
        SoundSoundFunction,
        SoundVariableInstancer>
    {
    }
}