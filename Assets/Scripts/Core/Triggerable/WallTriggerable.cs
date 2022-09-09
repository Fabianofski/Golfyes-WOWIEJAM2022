// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Triggerable
{
    public class WallTriggerable : MonoBehaviour, ITriggerable
    {
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private Sound wallSound;
        private Collider2D _collider2D;

        private void Start()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        public void Trigger(float offset)
        {
            Invoke(nameof(SetWallActive), offset);
        }

        public void Trigger(bool ballIsStill)
        {
            if (ballIsStill) SetWallActive();
        }

        private void SetWallActive()
        {
            playSoundEvent.Raise(wallSound);
            LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1), .3f).setEase(LeanTweenType.punch);
            _collider2D.enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}