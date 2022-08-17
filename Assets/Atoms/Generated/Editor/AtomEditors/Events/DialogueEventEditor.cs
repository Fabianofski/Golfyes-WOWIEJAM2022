#if UNITY_2019_1_OR_NEWER
using F4B1.Core.AI;
using UnityAtoms.Editor;
using UnityEditor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    ///     Event property drawer of type `F4B1.Core.Dialogue`. Inherits from `AtomEventEditor&lt;F4B1.Core.Dialogue,
    ///     DialogueEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(DialogueEvent))]
    public sealed class DialogueEventEditor : AtomEventEditor<Dialogue, DialogueEvent>
    {
    }
}
#endif