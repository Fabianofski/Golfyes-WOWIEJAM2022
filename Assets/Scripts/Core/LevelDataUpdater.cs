using System.Collections;
using System.Collections.Generic;
using F4B1.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class LevelDataUpdater : MonoBehaviour
    {

        [SerializeField] private LevelData levelData;
        [SerializeField] private IntVariable strokes;

        public void UpdateLevelData(bool levelIsComplete)
        {
            if (!levelIsComplete) return;

            levelData.StrokeSession = strokes.Value;
        }
    }
}
