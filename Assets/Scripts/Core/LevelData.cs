// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1.Core
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "new LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public int levelID;
        public int par;
        public int strokeSession = -1;

        public void ResetStrokeSession()
        {
            strokeSession = -1;
        }
    }
}