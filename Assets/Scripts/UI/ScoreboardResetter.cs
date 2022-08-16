// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI
{
    public class ScoreboardResetter : MonoBehaviour
    {
        [SerializeField] private LevelDataValueList levelData;

        public void Reset()
        {
            foreach (var data in levelData) data.ResetStrokeSession();
        }
    }
}