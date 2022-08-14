using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1
{
    public class TransparentTrigger : MonoBehaviour
    {

        [SerializeField] private float opacity = 0.4f;
        [SerializeField] private BoolVariable levelIsComplete;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            SetOpacity(opacity);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if(levelIsComplete.Value) SetOpacity(1);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            SetOpacity(1);
        }

        public void DisableAnimator()
        {
            SetOpacity(1);
            GetComponent<Animator>().enabled = false;
        }

        private void SetOpacity(float a)
        {
            var color = _spriteRenderer.color;
            color.a = a;
            _spriteRenderer.color = color;
        }
    }
}
