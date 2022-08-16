using F4B1.Audio;
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Variable Inspector of type `F4B1.Audio.Sound`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(SoundVariable))]
    public sealed class SoundVariableEditor : AtomVariableEditor<Sound, SoundPair>
    {
    }
}