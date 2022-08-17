using F4B1.Core;
using F4B1.UI.Scoreboard;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Event of type `F4B1.Core.LevelData`. Inherits from `AtomEvent&lt;F4B1.Core.LevelData&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/LevelData", fileName = "LevelDataEvent")]
    public sealed class LevelDataEvent : AtomEvent<LevelData>
    {
    }
}