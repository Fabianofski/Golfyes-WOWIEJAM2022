#if UNITY_2019_1_OR_NEWER
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Event property drawer of type `SoundPair`. Inherits from `AtomEventEditor&lt;SoundPair, SoundPairEvent&gt;`. Only
    ///     availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(SoundPairEvent))]
    public sealed class SoundPairEventEditor : AtomEventEditor<SoundPair, SoundPairEvent>
    {
    }
}
#endif