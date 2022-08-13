using Atoms.Generated;
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `F4B1.Core.Dialogue`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(DialogueVariable))]
    public sealed class DialogueVariableEditor : AtomVariableEditor<Dialogue, DialoguePair> { }
}
