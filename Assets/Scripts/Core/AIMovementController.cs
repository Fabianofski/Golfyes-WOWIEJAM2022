using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace F4B1.Core
{
    public class AIMovementController : MonoBehaviour
    {

        [SerializeField] private List<Transform> talkingPositions;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private LeanTweenType moveTweenType;
        [SerializeField] private float aiOpacity;
        [SerializeField] private float speed;

        [Header("Borders")] 
        [SerializeField] private float maxIdleTime;
        [SerializeField] private Vector2 bottomLeft;
        [SerializeField] private Vector2 topRight;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(nameof(MoveToRandomPosition));
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
            yield return new WaitForSeconds((distance / speed) + maxIdleTime);

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
            var offsetStart = RandomVector();
            var offsetEnd = RandomVector();
            
            var pts = new []{ startPos, endPos + offsetEnd, startPos + offsetStart, 
                          endPos};
            return new LTBezierPath(pts);
        }
        
        private static Vector3 RandomVector()
        {
            var x = Random.Range(-5, 5);
            var y = Random.Range(-5, 5);
            var z = Random.Range(-5, 5);
            return new Vector3(x, y, z);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;;
            Gizmos.DrawLine(bottomLeft, new Vector2(bottomLeft.x, topRight.y));
            Gizmos.DrawLine(bottomLeft, new Vector2(topRight.x, bottomLeft.y));
            Gizmos.DrawLine(topRight, new Vector2(topRight.x, bottomLeft.y));
            Gizmos.DrawLine(topRight, new Vector2(bottomLeft.x, topRight.y));


        }
    }
}