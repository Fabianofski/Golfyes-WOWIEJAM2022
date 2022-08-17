// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI.Scoreboard
{
    public class LevelDataUpdater : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        [SerializeField] private IntVariable strokes;

        public void UpdateLevelData(bool levelIsComplete)
        {
            if (!levelIsComplete) return;

            Debug.Log($"Updater: {levelData.strokeSession}");
            levelData.strokeSession = strokes.Value;
        }
    }
}