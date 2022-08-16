using F4B1.Core;
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Variable Inspector of type `F4B1.Core.LevelData`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(LevelDataVariable))]
    public sealed class LevelDataVariableEditor : AtomVariableEditor<LevelData, LevelDataPair>
    {
    }
}