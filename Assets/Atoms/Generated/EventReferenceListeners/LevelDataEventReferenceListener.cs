using F4B1.Core;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Event Reference Listener of type `F4B1.Core.LevelData`. Inherits from `AtomEventReferenceListener&lt;
    ///     F4B1.Core.LevelData, LevelDataEvent, LevelDataEventReference, LevelDataUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/LevelData Event Reference Listener")]
    public sealed class LevelDataEventReferenceListener : AtomEventReferenceListener<
        LevelData,
        LevelDataEvent,
        LevelDataEventReference,
        LevelDataUnityEvent>
    {
    }
}