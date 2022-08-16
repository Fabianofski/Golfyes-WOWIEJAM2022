using System;
using F4B1.Core;
using UnityEngine.Events;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     None generic Unity Event of type `F4B1.Core.LevelData`. Inherits from `UnityEvent&lt;F4B1.Core.LevelData&gt;`.
    /// </summary>
    [Serializable]
    public sealed class LevelDataUnityEvent : UnityEvent<LevelData>
    {
    }
}