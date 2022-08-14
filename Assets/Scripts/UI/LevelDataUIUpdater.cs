using System;
using F4B1.Core;
using TMPro;
using UnityEngine;

namespace F4B1.UI
{
    public class LevelDataUIUpdater : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI hole;
        [SerializeField] private TextMeshProUGUI par;
        [SerializeField] private TextMeshProUGUI score;
        
        public void UpdateData(LevelData data)
        {
            hole.text = data.levelID + "";
            par.text = data.par + "";
            score.text = data.StrokeSession == -1 ? "-" : data.StrokeSession + "";
        }
        
    }
}