using F4B1.Core.AI;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Variable Instancer of type `F4B1.Core.Dialogue`. Inherits from `AtomVariableInstancer&lt;DialogueVariable,
    ///     DialoguePair, F4B1.Core.Dialogue, DialogueEvent, DialoguePairEvent, DialogueDialogueFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/Dialogue Variable Instancer")]
    public class DialogueVariableInstancer : AtomVariableInstancer<
        DialogueVariable,
        DialoguePair,
        Dialogue,
        DialogueEvent,
        DialoguePairEvent,
        DialogueDialogueFunction>
    {
    }
}