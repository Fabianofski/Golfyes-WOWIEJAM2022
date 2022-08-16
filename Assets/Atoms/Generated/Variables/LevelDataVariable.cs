using System;
using F4B1.Core;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Variable of type `F4B1.Core.LevelData`. Inherits from `AtomVariable&lt;F4B1.Core.LevelData, LevelDataPair,
    ///     LevelDataEvent, LevelDataPairEvent, LevelDataLevelDataFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/LevelData", fileName = "LevelDataVariable")]
    public sealed class LevelDataVariable : AtomVariable<LevelData, LevelDataPair, LevelDataEvent, LevelDataPairEvent,
        LevelDataLevelDataFunction>
    {
        protected override bool ValueEquals(LevelData other)
        {
            throw new NotImplementedException();
        }
    }
}