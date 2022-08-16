#if UNITY_2019_1_OR_NEWER
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Event property drawer of type `DialoguePair`. Inherits from `AtomDrawer&lt;DialoguePairEvent&gt;`. Only availble in
    ///     `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(DialoguePairEvent))]
    public class DialoguePairEventDrawer : AtomDrawer<DialoguePairEvent>
    {
    }
}
#endif