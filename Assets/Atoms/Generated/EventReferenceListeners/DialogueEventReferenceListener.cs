using UnityEngine;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `F4B1.Core.Dialogue`. Inherits from `AtomEventReferenceListener&lt;F4B1.Core.Dialogue, DialogueEvent, DialogueEventReference, DialogueUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/Dialogue Event Reference Listener")]
    public sealed class DialogueEventReferenceListener : AtomEventReferenceListener<
        F4B1.Core.Dialogue,
        DialogueEvent,
        DialogueEventReference,
        DialogueUnityEvent>
    { }
}
