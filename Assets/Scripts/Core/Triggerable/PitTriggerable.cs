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
        private Collider2D _collider2D;
        
        [Header("Pit")]
        [SerializeField] private float ballSpeedThreshold;
        [SerializeField] private BoolVariable levelIsCompleted;
        private bool _inPit;
        [SerializeField] private bool oneTimePit;
        
        [Header("Sounds")] 
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private Sound ballInPit;
        [SerializeField] private Sound ballOverPit;

        private void Start()
        {
            _collider2D = GetComponent<Collider2D>();
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
            _collider2D.enabled = true;
            transform.localScale = Vector3.one;
            LeanTween.scale(gameObject, new Vector3(1.2f,1.2f,1), .3f).setEase(LeanTweenType.punch);
        }
        
        private void OnTriggerStay2D(Collider2D col)
        {
            if (levelIsCompleted.Value || _inPit) return;
            if (!col.gameObject.CompareTag("BallTrigger")) return;

            var rb2d = col.GetComponentInParent<Rigidbody2D>();
            if (!(rb2d.velocity.magnitude < ballSpeedThreshold)) return;

            Debug.Log("Pit");
            _inPit = true;
            rb2d.velocity = Vector2.zero;
            playSoundEvent.Raise(ballInPit);
            LeanTween.move(col.transform.parent.gameObject, transform.position, ballTweenDuration);
            LeanTween.scale(col.transform.parent.gameObject, Vector3.zero, ballTweenDuration).setEase(scaleTweenType).setOnComplete(
                () =>
                {
                    col.GetComponentInParent<BallController>().ResetToLastPosition();
                    if(oneTimePit) 
                        LeanTween.scale(gameObject, Vector3.zero, .3f).setEase(scaleTweenType).setOnComplete(() => Destroy(transform.parent.gameObject));
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