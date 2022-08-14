#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `F4B1.Core.LevelData`. Inherits from `AtomDrawer&lt;LevelDataEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(LevelDataEvent))]
    public class LevelDataEventDrawer : AtomDrawer<LevelDataEvent> { }
}
#endif
