using UnityEngine;
using F4B1.Core;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `F4B1.Core.LevelData`. Inherits from `AtomEventInstancer&lt;F4B1.Core.LevelData, LevelDataEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/LevelData Event Instancer")]
    public class LevelDataEventInstancer : AtomEventInstancer<F4B1.Core.LevelData, LevelDataEvent> { }
}