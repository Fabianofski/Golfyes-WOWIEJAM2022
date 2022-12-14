using System;
using F4B1.Core.AI;
using UnityEngine.Events;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     None generic Unity Event of type `F4B1.Core.Dialogue`. Inherits from `UnityEvent&lt;F4B1.Core.Dialogue&gt;`.
    /// </summary>
    [Serializable]
    public sealed class DialogueUnityEvent : UnityEvent<Dialogue>
    {
    }
}