using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Triggerable
{
    public class CoinTriggerable : MonoBehaviour, ITriggerable
    {

        private SpriteRenderer _spriteRenderer;
        private CircleCollider2D _circleCollider2D;
        [SerializeField] private IntVariable strokes;
        [SerializeField] private int coinAmount;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _circleCollider2D = GetComponent<CircleCollider2D>();
        }

        public void Trigger(float offset)
        {
            Invoke(nameof(SetCoinActive), offset);
        }

        public void Trigger(bool ballIsStill)
        {
            if(ballIsStill) SetCoinActive();
        }

        private void SetCoinActive()
        {
            GetComponent<Animator>().SetTrigger("FadeIn");
            _spriteRenderer.enabled = true;
            _circleCollider2D.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            strokes.Value += coinAmount;
            Destroy(gameObject);
        }
    }
}