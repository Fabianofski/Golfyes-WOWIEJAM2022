#if UNITY_2019_1_OR_NEWER
using F4B1.Core;
using F4B1.UI.Scoreboard;
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Event property drawer of type `F4B1.Core.LevelData`. Inherits from `AtomEventEditor&lt;F4B1.Core.LevelData,
    ///     LevelDataEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(LevelDataEvent))]
    public sealed class LevelDataEventEditor : AtomEventEditor<LevelData, LevelDataEvent>
    {
    }
}
#endif