using UnityEngine;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `F4B1.Core.Dialogue`. Inherits from `AtomEventInstancer&lt;F4B1.Core.Dialogue, DialogueEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/Dialogue Event Instancer")]
    public class DialogueEventInstancer : AtomEventInstancer<F4B1.Core.Dialogue, DialogueEvent> { }
}
