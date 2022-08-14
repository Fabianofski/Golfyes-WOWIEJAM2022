#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `F4B1.Core.LevelData`. Inherits from `AtomDrawer&lt;LevelDataVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(LevelDataVariable))]
    public class LevelDataVariableDrawer : VariableDrawer<LevelDataVariable> { }
}
#endif
