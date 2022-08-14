using System;
using UnityEngine;
using F4B1.Core;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;F4B1.Core.LevelData&gt;`. Inherits from `IPair&lt;F4B1.Core.LevelData&gt;`.
    /// </summary>
    [Serializable]
    public struct LevelDataPair : IPair<F4B1.Core.LevelData>
    {
        public F4B1.Core.LevelData Item1 { get => _item1; set => _item1 = value; }
        public F4B1.Core.LevelData Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private F4B1.Core.LevelData _item1;
        [SerializeField]
        private F4B1.Core.LevelData _item2;

        public void Deconstruct(out F4B1.Core.LevelData item1, out F4B1.Core.LevelData item2) { item1 = Item1; item2 = Item2; }
    }
}