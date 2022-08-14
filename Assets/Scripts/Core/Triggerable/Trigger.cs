﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Atoms.Generated;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Triggerable
{
    public class Trigger : MonoBehaviour
    {

        [SerializeField] private List<Triggerable> triggerables;
        [SerializeField] private DialogueEvent dialogueEvent;
        [SerializeField] private List<Dialogue> dialogues;
        [SerializeField] private bool oneTimeTrigger;
        private bool _ballInTrigger;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_ballInTrigger) return;
            _ballInTrigger = true;

            foreach (var t in triggerables)
                t.triggerableGameObject.GetComponent<ITriggerable>().Trigger(t.offset);
            foreach (var dialogue in dialogues)
                dialogueEvent.Raise(dialogue);
            
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