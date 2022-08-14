using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI
{
    public class IntTextUpdater : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        [SerializeField] private string unit;
        [SerializeField] private LeanTweenType tweenType;
        [SerializeField] private float tweenDuration;

        [Header("Colors")] 
        [SerializeField] private int endStrokes;
        [SerializeField] private IntVariable strokes;
        [SerializeField] private Color firstColor;
        [SerializeField] private Color endColor;
        
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateText(int value)
        {
            LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), tweenDuration / 2).setEase(tweenType).setOnComplete( 
                ()  =>
                {
                    _text.text = value + " " + unit;
                    LeanTween.scale(gameObject, Vector3.one, tweenDuration / 2).setEase(tweenType);
                });
            LeanTween.value(gameObject, SetColorCallback, _text.color, Color.Lerp(firstColor, endColor, (float) strokes.Value / endStrokes), tweenDuration/2);
        }
        
        private void SetColorCallback( Color c )
        {
            _text.color = c;
        }
    }
}
