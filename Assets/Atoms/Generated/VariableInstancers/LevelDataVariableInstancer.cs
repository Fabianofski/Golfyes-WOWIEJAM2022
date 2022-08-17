using F4B1.Core;
using F4B1.UI.Scoreboard;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Variable Instancer of type `F4B1.Core.LevelData`. Inherits from `AtomVariableInstancer&lt;LevelDataVariable,
    ///     LevelDataPair, F4B1.Core.LevelData, LevelDataEvent, LevelDataPairEvent, LevelDataLevelDataFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/LevelData Variable Instancer")]
    public class LevelDataVariableInstancer : AtomVariableInstancer<
        LevelDataVariable,
        LevelDataPair,
        LevelData,
        LevelDataEvent,
        LevelDataPairEvent,
        LevelDataLevelDataFunction>
    {
    }
}