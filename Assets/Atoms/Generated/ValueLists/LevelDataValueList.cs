using UnityEngine;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `F4B1.Core.LevelData`. Inherits from `AtomValueList&lt;F4B1.Core.LevelData, LevelDataEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/LevelData", fileName = "LevelDataValueList")]
    public sealed class LevelDataValueList : AtomValueList<F4B1.Core.LevelData, LevelDataEvent> { }
}
