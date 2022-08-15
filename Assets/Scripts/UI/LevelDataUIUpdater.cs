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
            Debug.Log($"Content: hole:{data.levelID} par: {data.par} score: {data.strokeSession}");
            
            hole.text = data.levelID + "";
            par.text = data.par + "";
            score.text = data.strokeSession == -1 ? "-" : data.strokeSession + "";
        }
        
    }
}