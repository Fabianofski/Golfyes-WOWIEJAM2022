using UnityEditor;
using UnityAtoms.Editor;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `F4B1.Core.Dialogue`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(DialogueVariable))]
    public sealed class DialogueVariableEditor : AtomVariableEditor<F4B1.Core.Dialogue, DialoguePair> { }
}
