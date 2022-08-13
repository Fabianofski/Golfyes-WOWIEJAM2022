using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace F4B1.Core
{
    public class AIController : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject speechBubble;
        [SerializeField] private LeanTweenType speechBubbleTweenType;
        private Queue<char> _characterQueue;        
        private Queue<Dialogue> _dialogueQueue;
        private float _timePerChar;
        private bool _coroutineRunning;


        private void Start()
        {
            _dialogueQueue = new Queue<Dialogue>();
        }

        public void PlayDialogue(Dialogue dialogue)
        {
            _dialogueQueue.Enqueue(dialogue);
            if(!_coroutineRunning) FillCharQueue();
        }

        private void FillCharQueue()
        {
            _characterQueue = new Queue<char>();
            LeanTween.scale(speechBubble, Vector3.one, .3f).setEase(speechBubbleTweenType);
            Dialogue dialogue = _dialogueQueue.Dequeue();
            dialogueText.text = "";
            
            foreach (var character in dialogue.dialogueText)
                _characterQueue.Enqueue(character);
            _timePerChar = dialogue.voiceLine.clip.length / _characterQueue.Count;

            StopAllCoroutines();
            StartCoroutine(nameof(DisplayNextCharacter));
        }
        
        private IEnumerator DisplayNextCharacter()
        {
            _coroutineRunning = true;
            dialogueText.text += _characterQueue.Dequeue();
            yield return new WaitForSeconds(_timePerChar);
            
            if (_characterQueue.Count > 0) StartCoroutine(nameof(DisplayNextCharacter));
            else if (_dialogueQueue.Count > 0) FillCharQueue();
            else _coroutineRunning = false;
        }
        
    }
}
