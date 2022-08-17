using System;
using F4B1.Core.AI;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Variable of type `F4B1.Core.Dialogue`. Inherits from `AtomVariable&lt;F4B1.Core.Dialogue, DialoguePair,
    ///     DialogueEvent, DialoguePairEvent, DialogueDialogueFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/Dialogue", fileName = "DialogueVariable")]
    public sealed class DialogueVariable : AtomVariable<Dialogue, DialoguePair, DialogueEvent, DialoguePairEvent,
        DialogueDialogueFunction>
    {
        protected override bool ValueEquals(Dialogue other)
        {
            throw new NotImplementedException();
        }
    }
}