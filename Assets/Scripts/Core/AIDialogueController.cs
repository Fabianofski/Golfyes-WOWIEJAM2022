using System;
using System.Collections;
using System.Collections.Generic;
using Atoms.Generated;
using F4B1.Audio;
using TMPro;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace F4B1.Core
{
    public class AIDialogueController : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject speechBubble;
        [SerializeField] private LeanTweenType speechBubbleTweenType;
        [SerializeField] private Image emotionImage;
        [SerializeField] private SoundEvent playSoundEvent;
        private Queue<char> _characterQueue;        
        private Queue<Dialogue> _dialogueQueue;
        private float _timePerChar;
        [SerializeField] private BoolVariable aiTalking;
        
        [Header("Sound")] 
        [SerializeField] private Sound[] talkingSounds;


        private void Start()
        {
            _dialogueQueue = new Queue<Dialogue>();
        }

        public void PlayDialogue(Dialogue dialogue)
        {
            _dialogueQueue.Enqueue(dialogue);
            if(!aiTalking.Value) FillCharQueue();
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
            playSoundEvent.Raise(dialogue.voiceLine);
            emotionImage.sprite = dialogue.robotEmotion;
            StartCoroutine(nameof(DisplayNextCharacter));
        }
        
        private IEnumerator DisplayNextCharacter()
        {
            aiTalking.Value = true;
            dialogueText.text += _characterQueue.Dequeue();
            if(_characterQueue.Count % 3 == 0)
                playSoundEvent.Raise(talkingSounds[Random.Range(0,  talkingSounds.Length)]);
            yield return new WaitForSeconds(_timePerChar);
            
            if (_characterQueue.Count > 0) StartCoroutine(nameof(DisplayNextCharacter));
            else if (_dialogueQueue.Count > 0)
            {
                yield return new WaitForSeconds(1f);
                FillCharQueue();
            }
            else
            {
                yield return new WaitForSeconds(1f);
                
                aiTalking.Value = false;
                dialogueText.text = "";
                LeanTween.scale(speechBubble, Vector3.zero, .3f).setEase(speechBubbleTweenType);
            }
        }
        
    }
}
