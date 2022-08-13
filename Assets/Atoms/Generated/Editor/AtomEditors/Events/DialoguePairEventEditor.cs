#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `DialoguePair`. Inherits from `AtomEventEditor&lt;DialoguePair, DialoguePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(DialoguePairEvent))]
    public sealed class DialoguePairEventEditor : AtomEventEditor<DialoguePair, DialoguePairEvent> { }
}
#endif
