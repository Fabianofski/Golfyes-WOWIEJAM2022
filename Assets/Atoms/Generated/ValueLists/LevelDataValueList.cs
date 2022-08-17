using F4B1.Core;
using F4B1.UI.Scoreboard;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Value List of type `F4B1.Core.LevelData`. Inherits from `AtomValueList&lt;F4B1.Core.LevelData, LevelDataEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/LevelData", fileName = "LevelDataValueList")]
    public sealed class LevelDataValueList : AtomValueList<LevelData, LevelDataEvent>
    {
    }
}