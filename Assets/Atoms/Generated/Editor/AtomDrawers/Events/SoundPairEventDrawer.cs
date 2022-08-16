#if UNITY_2019_1_OR_NEWER
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Event property drawer of type `SoundPair`. Inherits from `AtomDrawer&lt;SoundPairEvent&gt;`. Only availble in
    ///     `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SoundPairEvent))]
    public class SoundPairEventDrawer : AtomDrawer<SoundPairEvent>
    {
    }
}
#endif