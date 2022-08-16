using System;
using F4B1.Audio;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     IPair of type `&lt;F4B1.Audio.Sound&gt;`. Inherits from `IPair&lt;F4B1.Audio.Sound&gt;`.
    /// </summary>
    [Serializable]
    public struct SoundPair : IPair<Sound>
    {
        [SerializeField] private Sound _item1;

        [SerializeField] private Sound _item2;

        public Sound Item1
        {
            get => _item1;
            set => _item1 = value;
        }

        public Sound Item2
        {
            get => _item2;
            set => _item2 = value;
        }

        public void Deconstruct(out Sound item1, out Sound item2)
        {
            item1 = Item1;
            item2 = Item2;
        }
    }
}