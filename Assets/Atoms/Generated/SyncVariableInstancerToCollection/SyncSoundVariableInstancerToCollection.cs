using F4B1.Audio;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    ///     Adds Variable Instancer's Variable of type F4B1.Audio.Sound to a Collection or List on OnEnable and removes it on
    ///     OnDestroy.
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync Sound Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class
        SyncSoundVariableInstancerToCollection : SyncVariableInstancerToCollection<Sound, SoundVariable,
            SoundVariableInstancer>
    {
    }
}