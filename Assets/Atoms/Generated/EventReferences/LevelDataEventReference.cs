using System;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Event Reference of type `F4B1.Core.LevelData`. Inherits from `AtomEventReference&lt;F4B1.Core.LevelData,
    ///     LevelDataVariable, LevelDataEvent, LevelDataVariableInstancer, LevelDataEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class LevelDataEventReference : AtomEventReference<
        LevelData,
        LevelDataVariable,
        LevelDataEvent,
        LevelDataVariableInstancer,
        LevelDataEventInstancer>, IGetEvent
    {
    }
}