using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Event Reference Listener of type `SoundPair`. Inherits from `AtomEventReferenceListener&lt;SoundPair,
    ///     SoundPairEvent, SoundPairEventReference, SoundPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/SoundPair Event Reference Listener")]
    public sealed class SoundPairEventReferenceListener : AtomEventReferenceListener<
        SoundPair,
        SoundPairEvent,
        SoundPairEventReference,
        SoundPairUnityEvent>
    {
    }
}