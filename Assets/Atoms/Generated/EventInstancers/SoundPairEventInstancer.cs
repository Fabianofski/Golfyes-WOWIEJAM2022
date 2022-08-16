using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Event Instancer of type `SoundPair`. Inherits from `AtomEventInstancer&lt;SoundPair, SoundPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/SoundPair Event Instancer")]
    public class SoundPairEventInstancer : AtomEventInstancer<SoundPair, SoundPairEvent>
    {
    }
}