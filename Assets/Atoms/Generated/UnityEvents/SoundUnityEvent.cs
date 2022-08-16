using System;
using F4B1.Audio;
using UnityEngine.Events;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     None generic Unity Event of type `F4B1.Audio.Sound`. Inherits from `UnityEvent&lt;F4B1.Audio.Sound&gt;`.
    /// </summary>
    [Serializable]
    public sealed class SoundUnityEvent : UnityEvent<Sound>
    {
    }
}