using System;
using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Triggerable
{
    public class PitTriggerable : MonoBehaviour, ITriggerable
    {
        
        
        [SerializeField] private LeanTweenType scaleTweenType = LeanTweenType.easeOutQuad;
        [SerializeField] private float tweenDuration = 1f;
        [SerializeField] private float ballTweenDuration = .5f;
        private BoxCollider2D _boxCollider2D;
        
        [Header("Pit")]
        [SerializeField] private float ballSpeedThreshold;
        [SerializeField] private float ballDistanceThreshold;
        [SerializeField] private BoolVariable levelIsCompleted;
        private bool _inPit;
        
        [Header("Sounds")] 
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private Sound ballInPit;
        [SerializeField] private Sound ballOverPit;

        private void Start()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public void Trigger(float offset)
        {
            Invoke(nameof(SpawnIn), offset);
        }

        public void Trigger(bool ballIsStill)
        {
            SpawnIn();
        }

        private void SpawnIn()
        {
            _boxCollider2D.enabled = true;
            transform.localScale = Vector3.zero;
            LeanTween.scale(gameObject, Vector3.one, tweenDuration).setEase(scaleTweenType);
        }
        
        private void OnTriggerStay2D(Collider2D col)
        {
            if (levelIsCompleted.Value || _inPit) return;
            if (!col.gameObject.CompareTag("Ball")) return;

            var rb2d = col.GetComponent<Rigidbody2D>();
            var ballDistance = Vector3.Distance(transform.position, col.transform.position) ;
            if (!(rb2d.velocity.magnitude < ballSpeedThreshold) || !(ballDistance < ballDistanceThreshold)) return;

            Debug.Log("Pit");
            _inPit = true;
            rb2d.velocity = Vector2.zero;
            playSoundEvent.Raise(ballInPit);
            LeanTween.move(col.gameObject, Vector3.zero, ballTweenDuration);
            LeanTween.scale(col.gameObject, Vector3.zero, ballTweenDuration).setEase(scaleTweenType).setOnComplete(
                () =>
                {
                    col.GetComponent<BallController>().ResetToLastPosition();
                    _inPit = false;
                });
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (levelIsCompleted.Value) return;
            if (!col.gameObject.CompareTag("Ball")) return;
            
            playSoundEvent.Raise(ballOverPit);
        }
    }
}