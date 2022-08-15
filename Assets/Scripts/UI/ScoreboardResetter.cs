using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI
{
    public class ScoreboardResetter : MonoBehaviour
    {

        [SerializeField] private LevelDataValueList levelData;

        public void Reset()
        {
            foreach (var data in levelData)
            {
                data.ResetStrokeSession();
            }
        }

    }
}