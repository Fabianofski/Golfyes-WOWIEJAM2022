using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace F4B1.Core
{
    public class BallController : MonoBehaviour
    {

        [Header("Shooting")] 
        private Rigidbody2D _rb2d;
        [SerializeField] private float dragLength;
        [SerializeField] private float shootPower;
        [SerializeField] private LayerMask layerMask;
        
        [SerializeField] private FloatVariable dragPower;
        private Vector2 _dir;
        [SerializeField] private RectTransform arrowTransform;
        
        private Vector2 _mousePos;
        private Vector2 _dragStartPos;
        private bool _dragging;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Shoot()
        {
            Debug.Log("Shoot");
            _rb2d.AddForce(dragPower.Value * _dir * shootPower, ForceMode2D.Impulse);
            dragPower.Value = 0;
        }

        private void Update()
        {
            if (_dragging) DrawPowerLine();
        }

        private void DrawPowerLine()
        {
            var distance = Vector2.Distance(_dragStartPos, _mousePos);
            dragPower.Value = Math.Min(1, distance / dragLength);

            _dir = (_dragStartPos - _mousePos).normalized;
            arrowTransform.eulerAngles = new Vector3(0,0,Vector2.SignedAngle(Vector2.up, _dir));
        }

        public void OnClickPosition(InputValue value)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        }

        public void OnClick(InputValue value)
        {
            if (value.isPressed)
            {
                var hit = Physics2D.Raycast(_mousePos, Vector2.zero, layerMask);
                if (!hit || !hit.transform.gameObject.Equals(gameObject)) return;
                _dragStartPos = _mousePos;
                _dragging = true;
            }
            else if (_dragging)
            {
                Shoot();
                _dragging = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawIcon(_mousePos, "Mouse");
        }
    }
}