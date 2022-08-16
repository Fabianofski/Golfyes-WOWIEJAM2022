// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F4B1.Core
{
    public class AIMovementController : MonoBehaviour
    {
        [SerializeField] private List<Transform> talkingPositions;

        [SerializeField] private LeanTweenType moveTweenType;
        [SerializeField] private float aiOpacity;
        [SerializeField] private float speed;

        [Header("Borders")] [SerializeField] private float maxIdleTime;

        [SerializeField] private float minIdleTime;
        [SerializeField] private Vector2 bottomLeft;
        [SerializeField] private Vector2 topRight;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(nameof(MoveToRandomPosition));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            ;
            Gizmos.DrawLine(bottomLeft, new Vector2(bottomLeft.x, topRight.y));
            Gizmos.DrawLine(bottomLeft, new Vector2(topRight.x, bottomLeft.y));
            Gizmos.DrawLine(topRight, new Vector2(topRight.x, bottomLeft.y));
            Gizmos.DrawLine(topRight, new Vector2(bottomLeft.x, topRight.y));
        }

        public void AITalkingChanged(bool aiTalking)
        {
            var color = _spriteRenderer.color;
            color.a = aiTalking ? 1 : aiOpacity;
            _spriteRenderer.color = color;

            LeanTween.cancel(gameObject);
            StopCoroutine(nameof(MoveToRandomPosition));

            if (aiTalking) MoveToTalkingPosition();
            else StartCoroutine(nameof(MoveToRandomPosition));
        }

        private IEnumerator MoveToRandomPosition()
        {
            var endPos = new Vector2(Random.Range(bottomLeft.x, topRight.x), Random.Range(bottomLeft.y, topRight.y));
            var position = transform.position;
            var path = CreateBezierPath(position, endPos);
            var distance = Vector3.Distance(position, endPos);


            LeanTween.move(gameObject, path, distance / speed);
            yield return new WaitForSeconds(distance / speed);

            var idleTime = Random.Range(minIdleTime, maxIdleTime);
            LeanTween.move(gameObject, (Vector3)endPos + RandomVector(1), idleTime).setEase(LeanTweenType.easeShake);

            yield return new WaitForSeconds(idleTime);

            StartCoroutine(nameof(MoveToRandomPosition));
        }

        private void MoveToTalkingPosition()
        {
            var randomTalkingPosition = talkingPositions[Random.Range(0, talkingPositions.Count)].position;
            var position = transform.position;
            var distance = Vector3.Distance(position, randomTalkingPosition);

            var path = CreateBezierPath(position, randomTalkingPosition);
            LeanTween.move(gameObject, path, distance / speed).setEase(moveTweenType);
        }

        private static LTBezierPath CreateBezierPath(Vector3 startPos, Vector3 endPos)
        {
            var offsetStart = RandomVector(5);
            var offsetEnd = RandomVector(5);

            var pts = new[]
            {
                startPos, endPos + offsetEnd, startPos + offsetStart,
                endPos
            };
            return new LTBezierPath(pts);
        }

        private static Vector3 RandomVector(float maxMagnitude)
        {
            var x = Random.Range(-maxMagnitude, maxMagnitude);
            var y = Random.Range(-maxMagnitude, maxMagnitude);
            var z = Random.Range(-maxMagnitude, maxMagnitude);
            return new Vector3(x, y, z);
        }
    }
}