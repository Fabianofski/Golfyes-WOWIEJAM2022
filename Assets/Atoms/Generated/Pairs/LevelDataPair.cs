using System;
using F4B1.Core;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     IPair of type `&lt;F4B1.Core.LevelData&gt;`. Inherits from `IPair&lt;F4B1.Core.LevelData&gt;`.
    /// </summary>
    [Serializable]
    public struct LevelDataPair : IPair<LevelData>
    {
        [SerializeField] private LevelData _item1;

        [SerializeField] private LevelData _item2;

        public LevelData Item1
        {
            get => _item1;
            set => _item1 = value;
        }

        public LevelData Item2
        {
            get => _item2;
            set => _item2 = value;
        }

        public void Deconstruct(out LevelData item1, out LevelData item2)
        {
            item1 = Item1;
            item2 = Item2;
        }
    }
}