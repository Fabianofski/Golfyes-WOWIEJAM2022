// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using TMPro;
using UnityEngine;

namespace F4B1.UI.Scoreboard
{
    public class LevelDataUIUpdater : MonoBehaviour
    {
        [Header("Colors")] 
        [SerializeField] private int worstPar;
        public int WorstPar { get => worstPar; set => worstPar = value; }
        [SerializeField] private Color firstColor;
        [SerializeField] private Color endColor;
        [SerializeField] private Color defaultColor;
        
        [Header("TextFields")]
        [SerializeField] private TextMeshProUGUI hole;
        [SerializeField] private TextMeshProUGUI par;
        [SerializeField] private TextMeshProUGUI score;

        public void UpdateData(LevelData data)
        {
            hole.text = data.levelID == -1 ? "S\nU\nM" : data.levelID + "";
            par.text = data.par + "";
            score.text = data.strokeSession == -1 ? "-" : data.strokeSession + "";
            score.color = GetScoreColor(data);
        }

        private Color GetScoreColor(LevelData data)
        {
            var overPar = data.strokeSession - data.par;
            var color = Color.Lerp(firstColor, endColor, (float) overPar / WorstPar);
            return data.strokeSession == -1 ? defaultColor : color;
        }
    }
}