using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private IntVariable strokes;
        [SerializeField] private bool triggerOnCertainStrokes;
        [SerializeField] private int[] triggerOnStrokes;
        [SerializeField] private int triggerEveryXStroke = 1;
        [SerializeField] private int minimumStrokes = 0;
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
            if (triggerOnCertainStrokes && !triggerOnStrokes.Contains(strokes.Value)) return;
            if (strokes.Value % triggerEveryXStroke != 0) return;
            if (strokes.Value < minimumStrokes) return;
            
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