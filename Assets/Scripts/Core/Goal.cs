// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System.Collections.Generic;
using F4B1.Audio;
using F4B1.Core.Triggerable;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class Goal : MonoBehaviour, ITriggerable
    {
        [Header("Goal")] 
        [SerializeField] private float ballSpeedThreshold;
        [SerializeField] private float ballDistanceThreshold;
        [SerializeField] private BoolVariable levelIsCompleted;

        [Header("Tweening - Ball Scaling")] 
        [SerializeField] private LeanTweenType ballScaleTweenType;
        [SerializeField] private float ballScaleTweenDuration;
        
        [Header("Tweening - Goal moving")] 
        private int _currentGoalPos;
        [SerializeField] private List<Transform> goalPositions;
        [SerializeField] private LeanTweenType goalMoveTweenType;
        [SerializeField] private float goalMoveTweenDuration;

        [Header("Sounds")] 
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private Sound ballInHoleSound;
        [SerializeField] private Sound ballOverHoleSound;

        private void OnTriggerExit2D(Collider2D col)
        {
            if (levelIsCompleted.Value) return;
            if (!col.gameObject.CompareTag("Ball")) return;

            playSoundEvent.Raise(ballOverHoleSound);
        }


        private void OnTriggerStay2D(Collider2D col)
        {
            if (levelIsCompleted.Value) return;
            if (!col.gameObject.CompareTag("Ball")) return;

            var rb2d = col.GetComponent<Rigidbody2D>();
            var ballDistance = Vector3.Distance(transform.position, col.transform.position);
            if (rb2d.velocity.magnitude < ballSpeedThreshold && ballDistance < ballDistanceThreshold)
            {
                Debug.Log("Goal");
                levelIsCompleted.Value = true;
                rb2d.velocity = Vector2.zero;
                col.transform.parent = transform;
                playSoundEvent.Raise(ballInHoleSound);
                LeanTween.moveLocal(col.gameObject, Vector3.zero, .3f);
                LeanTween.scale(col.gameObject, Vector3.zero, ballScaleTweenDuration).setEase(ballScaleTweenType);
            }
        }

        public void Trigger(float offset)
        {
            Invoke(nameof(MoveGoal), offset);
        }

        public void Trigger(bool ballIsStill)
        {
            if (!ballIsStill) MoveGoal();
        }

        private void MoveGoal()
        {
            if (_currentGoalPos < goalPositions.Count - 1)
                _currentGoalPos++;
            else _currentGoalPos = 0;
            LeanTween.move(gameObject, goalPositions[_currentGoalPos].position, goalMoveTweenDuration)
                .setEase(goalMoveTweenType);
        }
    }
}