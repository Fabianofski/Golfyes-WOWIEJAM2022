using F4B1.Audio;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Event of type `F4B1.Audio.Sound`. Inherits from `AtomEvent&lt;F4B1.Audio.Sound&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/Sound", fileName = "SoundEvent")]
    public sealed class SoundEvent : AtomEvent<Sound>
    {
    }
}