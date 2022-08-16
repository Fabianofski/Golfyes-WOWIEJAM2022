// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1.Core.Triggerable
{
    public class SwitchTriggerable : MonoBehaviour, ITriggerable
    {
        [SerializeField] private GameObject switch1;
        [SerializeField] private GameObject switch2;

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
            switch1.SetActive(!switch1.activeSelf);
            switch2.SetActive(!switch2.activeSelf);
            LeanTween.scale(switch1, new Vector3(1.2f, 1.2f, 1), .3f).setEase(LeanTweenType.punch);
            LeanTween.scale(switch2, new Vector3(1.2f, 1.2f, 1), .3f).setEase(LeanTweenType.punch);
        }
    }
}