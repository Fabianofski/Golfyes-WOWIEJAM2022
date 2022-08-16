#if UNITY_2019_1_OR_NEWER
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Event property drawer of type `LevelDataPair`. Inherits from `AtomDrawer&lt;LevelDataPairEvent&gt;`. Only availble
    ///     in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(LevelDataPairEvent))]
    public class LevelDataPairEventDrawer : AtomDrawer<LevelDataPairEvent>
    {
    }
}
#endif