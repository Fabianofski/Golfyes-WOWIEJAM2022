using F4B1.Core.AI;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Event of type `F4B1.Core.Dialogue`. Inherits from `AtomEvent&lt;F4B1.Core.Dialogue&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/Dialogue", fileName = "DialogueEvent")]
    public sealed class DialogueEvent : AtomEvent<Dialogue>
    {
    }
}