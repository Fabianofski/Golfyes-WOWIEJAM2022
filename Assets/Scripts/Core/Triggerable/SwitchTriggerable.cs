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
    public class SwitchTriggerable : MonoBehaviour, ITriggerable
    {
        [SerializeField] private GameObject switch1;
        [SerializeField] private GameObject switch2;
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private Sound switchSound;
        
        public void Trigger(float offset)
        {
            Invoke(nameof(SwitchObjects), offset);
        }

        public void Trigger(bool ballIsStill)
        {
            if (ballIsStill) SwitchObjects();
        }

        private void SwitchObjects()
        {
            playSoundEvent.Raise(switchSound);
            switch1.SetActive(!switch1.activeSelf);
            switch2.SetActive(!switch2.activeSelf);
            LeanTween.scale(switch1, new Vector3(1.2f, 1.2f, 1), .3f).setEase(LeanTweenType.punch);
            LeanTween.scale(switch2, new Vector3(1.2f, 1.2f, 1), .3f).setEase(LeanTweenType.punch);
        }
    }
}