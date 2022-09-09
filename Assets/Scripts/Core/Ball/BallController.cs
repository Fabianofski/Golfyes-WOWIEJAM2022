// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace F4B1.Core.Ball
{
    public class BallController : MonoBehaviour
    {
        [Header("Dragging")]
        private bool _dragging;
        private Vector2 _dragStartPos;
        private Vector2 _mousePos;
        [SerializeField] private float dragLength;
        [SerializeField] private FloatVariable dragPower;
        [SerializeField] private RectTransform arrowTransform;
        
        [Header("Shooting")] 
        private Rigidbody2D _rb2d;
        private Vector2 _lastPos;
        [SerializeField] private float shootPower;
        [SerializeField] private IntVariable strokes;
        [SerializeField] private float rollSpeed;
        private Material _material;
        
        [Header("Ground")] 
        private bool _onSand;
        [SerializeField] private float dragOnGrass;
        [SerializeField] private float dragOnSand;
        [SerializeField] private float sandShootDamper;
        
        [Header("Conditions")]
        [SerializeField] private BoolVariable ballIsStill;
        [SerializeField] private BoolVariable levelIsComplete;
        [SerializeField] private BoolVariable gameIsPaused;
        [SerializeField] private BoolVariable aiTalking;
        
        [Header("Sound")] 
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private Sound ballHitsWallSound;
        [SerializeField] private Sound ballGetsHitSound;
        [SerializeField] private float soundDamper;
        private Vector2 _dir;

        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ballIsStill.Value = _rb2d.velocity.magnitude < .1f;
            if (_dragging && ballIsStill.Value) DrawPowerLine();
            if (!ballIsStill.Value) RollBallMaterial();
        }

        private void Shoot()
        {
            if (!ballIsStill.Value || dragPower.Value < .1f) return;
            strokes.Value++;
            var modifier = _onSand ? sandShootDamper : 1;
            _rb2d.AddForce(MathF.Pow(dragPower.Value, 2) * _dir * shootPower * modifier, ForceMode2D.Impulse);
            ballGetsHitSound.volume = dragPower.Value * .7f;
            playSoundEvent.Raise(ballGetsHitSound);
            dragPower.Value = 0;
        }

        private void DrawPowerLine()
        {
            var distance = Vector2.Distance(_dragStartPos, _mousePos);
            dragPower.Value = Math.Min(1, distance / dragLength);

            _dir = (_dragStartPos - _mousePos).normalized;
            arrowTransform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, _dir));
        }

        public void OnClickPosition(InputValue value)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        }

        public void OnClick(InputValue value)
        {
            if (!ballIsStill.Value || gameIsPaused.Value || levelIsComplete.Value || aiTalking.Value) return;

            if (value.isPressed)
            {
                _lastPos = transform.position;
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

        public void ResetToLastPosition()
        {
            var trans = transform;
            trans.localScale = Vector3.one;
            trans.position = _lastPos;
        }
        
        public void SandGroundChanged(bool onSand)
        {
            _onSand = onSand;

            _rb2d.drag = _onSand ? dragOnSand : dragOnGrass;
        }
        
        private void RollBallMaterial()
        {
            _material.mainTextureOffset -= _rb2d.velocity * (Time.deltaTime * rollSpeed);
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            ballHitsWallSound.volume = Math.Min(1, Mathf.Sqrt(Mathf.Abs(_rb2d.velocity.magnitude)) / soundDamper);
            playSoundEvent.Raise(ballHitsWallSound);
        }
    }
}