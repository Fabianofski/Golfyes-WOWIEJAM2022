using F4B1.Audio;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Event Reference Listener of type `F4B1.Audio.Sound`. Inherits from `AtomEventReferenceListener&lt;F4B1.Audio.Sound,
    ///     SoundEvent, SoundEventReference, SoundUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/Sound Event Reference Listener")]
    public sealed class SoundEventReferenceListener : AtomEventReferenceListener<
        Sound,
        SoundEvent,
        SoundEventReference,
        SoundUnityEvent>
    {
    }
}