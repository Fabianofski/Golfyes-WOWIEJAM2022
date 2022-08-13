using F4B1.Audio;
using UnityEngine;

namespace F4B1.Core
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/New Dialogue", order = 0)]
    public class Dialogue : ScriptableObject
    {
        [TextArea(3,10)]
        public string dialogueText;
        public Sound voiceLine;
    }
}