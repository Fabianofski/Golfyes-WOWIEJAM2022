using System;
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
        [SerializeField] private bool triggerOnZoneEnter;
        [SerializeField] private bool triggerOnStart;
        [SerializeField] private bool triggerOnStrokeEnd;
        [SerializeField] private bool triggerOnStroke;
        private bool _ballInTrigger;

        private void Start()
        {
            if(triggerOnStart) TriggerAllTriggerables();
        }

        public void BallIsStillChanged(bool ballIsStill)
        {
            if (triggerOnStrokeEnd && ballIsStill) TriggerAllTriggerables();
            else if (triggerOnStroke && !ballIsStill) TriggerAllTriggerables();
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_ballInTrigger || !triggerOnZoneEnter) return;
            _ballInTrigger = true;

            TriggerAllTriggerables();
        }

        private void TriggerAllTriggerables()
        {
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