using System;
using F4B1.Core.AI;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     IPair of type `&lt;F4B1.Core.Dialogue&gt;`. Inherits from `IPair&lt;F4B1.Core.Dialogue&gt;`.
    /// </summary>
    [Serializable]
    public struct DialoguePair : IPair<Dialogue>
    {
        [SerializeField] private Dialogue _item1;

        [SerializeField] private Dialogue _item2;

        public Dialogue Item1
        {
            get => _item1;
            set => _item1 = value;
        }

        public Dialogue Item2
        {
            get => _item2;
            set => _item2 = value;
        }

        public void Deconstruct(out Dialogue item1, out Dialogue item2)
        {
            item1 = Item1;
            item2 = Item2;
        }
    }
}