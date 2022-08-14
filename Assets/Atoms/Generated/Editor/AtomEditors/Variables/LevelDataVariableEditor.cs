using UnityEditor;
using UnityAtoms.Editor;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `F4B1.Core.LevelData`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(LevelDataVariable))]
    public sealed class LevelDataVariableEditor : AtomVariableEditor<F4B1.Core.LevelData, LevelDataPair> { }
}
