#if UNITY_2019_1_OR_NEWER
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Event property drawer of type `F4B1.Audio.Sound`. Inherits from `AtomDrawer&lt;SoundEvent&gt;`. Only availble in
    ///     `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SoundEvent))]
    public class SoundEventDrawer : AtomDrawer<SoundEvent>
    {
    }
}
#endif