#if UNITY_2019_1_OR_NEWER
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Value List property drawer of type `F4B1.Core.LevelData`. Inherits from `AtomDrawer&lt;LevelDataValueList&gt;`.
    ///     Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(LevelDataValueList))]
    public class LevelDataValueListDrawer : AtomDrawer<LevelDataValueList>
    {
    }
}
#endif