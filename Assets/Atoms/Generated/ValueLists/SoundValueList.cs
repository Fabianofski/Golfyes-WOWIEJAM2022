using F4B1.Audio;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Value List of type `F4B1.Audio.Sound`. Inherits from `AtomValueList&lt;F4B1.Audio.Sound, SoundEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/Sound", fileName = "SoundValueList")]
    public sealed class SoundValueList : AtomValueList<Sound, SoundEvent>
    {
    }
}