using System;
using F4B1.Audio;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Reference of type `F4B1.Audio.Sound`. Inherits from `AtomReference&lt;F4B1.Audio.Sound, SoundPair, SoundConstant,
    ///     SoundVariable, SoundEvent, SoundPairEvent, SoundSoundFunction, SoundVariableInstancer, AtomCollection, AtomList&gt;
    ///     `.
    /// </summary>
    [Serializable]
    public sealed class SoundReference : AtomReference<
        Sound,
        SoundPair,
        SoundConstant,
        SoundVariable,
        SoundEvent,
        SoundPairEvent,
        SoundSoundFunction,
        SoundVariableInstancer>, IEquatable<SoundReference>
    {
        public SoundReference()
        {
        }

        public SoundReference(Sound value) : base(value)
        {
        }

        public bool Equals(SoundReference other)
        {
            return base.Equals(other);
        }

        protected override bool ValueEquals(Sound other)
        {
            throw new NotImplementedException();
        }
    }
}