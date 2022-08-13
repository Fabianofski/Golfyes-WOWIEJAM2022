#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `F4B1.Core.Dialogue`. Inherits from `AtomDrawer&lt;DialogueVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(DialogueVariable))]
    public class DialogueVariableDrawer : VariableDrawer<DialogueVariable> { }
}
#endif
