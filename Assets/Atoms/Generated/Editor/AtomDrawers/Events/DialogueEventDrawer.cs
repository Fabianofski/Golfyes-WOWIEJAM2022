#if UNITY_2019_1_OR_NEWER
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Event property drawer of type `F4B1.Core.Dialogue`. Inherits from `AtomDrawer&lt;DialogueEvent&gt;`. Only availble
    ///     in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(DialogueEvent))]
    public class DialogueEventDrawer : AtomDrawer<DialogueEvent>
    {
    }
}
#endif