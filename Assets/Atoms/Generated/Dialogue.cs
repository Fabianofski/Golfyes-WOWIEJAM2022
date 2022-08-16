using F4B1.Audio;
using UnityEngine;

namespace Atoms.Generated
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/New Dialogue", order = 0)]
    public class Dialogue : ScriptableObject
    {
        [TextArea(3, 10)] public string dialogueText;

        public Sound voiceLine;
        public Sprite robotEmotion;
    }
}