using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `DialoguePair`. Inherits from `AtomEvent&lt;DialoguePair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/DialoguePair", fileName = "DialoguePairEvent")]
    public sealed class DialoguePairEvent : AtomEvent<DialoguePair>
    {
    }
}
