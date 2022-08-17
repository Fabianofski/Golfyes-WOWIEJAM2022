using F4B1.Core.AI;
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Variable Inspector of type `F4B1.Core.Dialogue`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(DialogueVariable))]
    public sealed class DialogueVariableEditor : AtomVariableEditor<Dialogue, DialoguePair>
    {
    }
}