﻿using System;
using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI
{
    public class TweenIn : MonoBehaviour
    {

        [SerializeField] private SoundEvent raiseSoundEvent;
        [SerializeField] private Sound wooshSound;
        [SerializeField] private LeanTweenType scaleTweenType = LeanTweenType.easeOutQuad;
        [SerializeField] private float tweenDuration = .3f;
        [SerializeField] private float delay = 0.02f;
        
        private void OnEnable()
        {
            TweenGameObject(gameObject, 0);
            TweenChildren(transform, delay);
        }

        private void TweenChildren(Transform trans, float delay)
        {
            for (int i = 0; i < trans.childCount; i++)
            {
                if(trans.GetChild(i).childCount > 0) TweenChildren(trans.GetChild(i), delay);
                TweenGameObject(trans.GetChild(i).gameObject, i * delay);
            }
        }

        private void TweenGameObject(GameObject go, float delay)
        {
            go.transform.localScale = Vector3.zero;
            raiseSoundEvent.Raise(wooshSound);
            LeanTween.scale(go, Vector3.one, tweenDuration).setEase(scaleTweenType).setDelay(delay);
        }
    }
}