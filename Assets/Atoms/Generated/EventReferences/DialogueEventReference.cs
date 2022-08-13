using System;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `F4B1.Core.Dialogue`. Inherits from `AtomEventReference&lt;F4B1.Core.Dialogue, DialogueVariable, DialogueEvent, DialogueVariableInstancer, DialogueEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class DialogueEventReference : AtomEventReference<
        F4B1.Core.Dialogue,
        DialogueVariable,
        DialogueEvent,
        DialogueVariableInstancer,
        DialogueEventInstancer>, IGetEvent 
    { }
}
