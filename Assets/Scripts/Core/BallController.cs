using System;
using System.Collections;
using System.Collections.Generic;
using F4B1.Audio;
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
        [SerializeField] private IntVariable strokes;
        
        [SerializeField] private FloatVariable dragPower;
        private Vector2 _dir;
        [SerializeField] private RectTransform arrowTransform;
        
        private Vector2 _mousePos;
        private Vector2 _dragStartPos;
        private bool _dragging;
        [SerializeField] private BoolVariable ballIsStill;
        [SerializeField] private BoolVariable levelIsComplete;
        [SerializeField] private BoolVariable gameIsPaused;
        private Material _material;
        [SerializeField] private float rollSpeed;

        [Header("Sound")] 
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private Sound ballHitsWallSound;
        [SerializeField] private float soundDamper;

        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
            Debug.Log(_material.name);
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Shoot()
        {
            if (!ballIsStill.Value || dragPower.Value < .1f) return;
            strokes.Value++;
            _rb2d.AddForce(MathF.Pow(dragPower.Value, 2) * _dir * shootPower, ForceMode2D.Impulse);
            dragPower.Value = 0;
        }

        private void Update()
        {
            ballIsStill.Value = _rb2d.velocity.magnitude < .1f;
            if (_dragging && ballIsStill.Value) DrawPowerLine();
            if(!ballIsStill.Value) RollBallMaterial();
        }

        private void RollBallMaterial()
        {
            _material.mainTextureOffset -= _rb2d.velocity * (Time.deltaTime * rollSpeed);
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
            if (!ballIsStill.Value || gameIsPaused.Value || levelIsComplete.Value) return;

            if (value.isPressed)
            {
                arrowTransform.localScale = Vector3.one;
                _dragStartPos = _mousePos;
                _dragging = true;
            }
            else if (_dragging)
            {
                arrowTransform.localScale = Vector3.zero;
                Shoot();
                _dragging = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawIcon(_mousePos, "Mouse");
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            ballHitsWallSound.volume = Math.Min(1, Mathf.Sqrt(Mathf.Abs(_rb2d.velocity.magnitude)) / soundDamper);
            playSoundEvent.Raise(ballHitsWallSound);
        }
    }
}
