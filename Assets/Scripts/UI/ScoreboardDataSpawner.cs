using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI
{
    public class ScoreboardDataSpawner : MonoBehaviour
    {
        [SerializeField] private LevelDataValueList levelDataList;
        [SerializeField] private Transform container;
        [SerializeField] private GameObject levelDataPrefab;
        
        
        private void OnEnable()
        {
            for (int i = 0; i < container.childCount; i++)
            {
                Destroy(container.GetChild(i).gameObject);
            }
            
            foreach (var data in levelDataList.List)
            {
                var go = Instantiate(levelDataPrefab, container);
                go.GetComponent<LevelDataUIUpdater>().UpdateData(data);
            }
        }
    }
}