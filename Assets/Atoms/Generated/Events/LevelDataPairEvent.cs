using UnityEngine;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `LevelDataPair`. Inherits from `AtomEvent&lt;LevelDataPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/LevelDataPair", fileName = "LevelDataPairEvent")]
    public sealed class LevelDataPairEvent : AtomEvent<LevelDataPair>
    {
    }
}
