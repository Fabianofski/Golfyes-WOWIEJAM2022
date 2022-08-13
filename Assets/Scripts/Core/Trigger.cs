using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace F4B1.Core
{
    public class Trigger : MonoBehaviour
    {

        [SerializeField] private List<Triggerable> triggerables;
        [SerializeField] private bool oneTimeTrigger;
        private bool _ballInTrigger;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_ballInTrigger) return;
            _ballInTrigger = true;

            foreach (var t in triggerables)
                t.triggerableGameObject.GetComponent<ITriggerable>().Trigger(t.offset);
            if (oneTimeTrigger) Destroy(gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _ballInTrigger = false;
        }

        [Serializable]
        public struct Triggerable
        {
            public GameObject triggerableGameObject;
            public float offset;
        }
        
    }
}