// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI.Scoreboard
{
    public class ScoreboardDataSpawner : MonoBehaviour
    {
        [SerializeField] private LevelDataValueList levelDataList;
        [SerializeField] private Transform container;
        [SerializeField] private Transform summaryContainer;
        [SerializeField] private GameObject levelDataPrefab;
        [SerializeField] private int totalWorstPar = 8;

        private void OnEnable()
        {
            FillScoreboard();
            AddSummaryToScoreboard();
        }

        private void FillScoreboard()
        {
            for (var i = 0; i < container.childCount; i++) Destroy(container.GetChild(i).gameObject);
            for (var i = 0; i < summaryContainer.childCount; i++) Destroy(summaryContainer.GetChild(i).gameObject);

            foreach (var data in levelDataList.List)
            {
                var go = Instantiate(levelDataPrefab, container);
                go.GetComponent<LevelDataUIUpdater>().UpdateData(data);
            }
        }

        private void AddSummaryToScoreboard()
        {
            var summary = ScriptableObject.CreateInstance<LevelData>();
            var parSum = 0;
            var strokeSum = 0;
            
            foreach (var data in levelDataList.List)
            {
                parSum += data.par;
                strokeSum += data.strokeSession == -1 ? 0 : data.strokeSession;
            }

            summary.levelID = -1;
            summary.par = parSum;
            summary.strokeSession = strokeSum;
            var summaryGo = Instantiate(levelDataPrefab, summaryContainer);
            Destroy(summaryGo.transform.Find("Dividers").gameObject);
            var uiUpdater = summaryGo.GetComponent<LevelDataUIUpdater>();
            uiUpdater.WorstPar = totalWorstPar;
            uiUpdater.UpdateData(summary);
        }
    }
}