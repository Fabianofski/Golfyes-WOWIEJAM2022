// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System.Collections;
using System.Collections.Generic;
using F4B1.Audio;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace F4B1.Core.AI
{
    public class AIDialogueController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject speechBubble;
        [SerializeField] private LeanTweenType speechBubbleTweenType;
        [SerializeField] private Image emotionImage;
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private BoolVariable aiTalking;
        [SerializeField] private float defaultTimePerChar = 0.05f;
        [SerializeField] private InputAction skipDialogueAction;


        [Header("Sound")] [SerializeField] private Sound[] talkingSounds;

        [SerializeField] private VoidEvent destroySoundEvent;
        private Queue<char> _characterQueue;
        private Queue<Dialogue> _dialogueQueue;
        private float _timePerChar;


        private void Awake()
        {
            _dialogueQueue = new Queue<Dialogue>();
            skipDialogueAction.performed += _ => OnSkip();
        }

        private void OnEnable()
        {
            skipDialogueAction.Enable();
        }

        private void OnDisable()
        {
            skipDialogueAction.Disable();
        }

        private void OnSkip()
        {
            StopCoroutine(DisplayNextCharacter());
            destroySoundEvent.Raise();
            _characterQueue.Clear();
            if (_dialogueQueue.Count > 0) FillCharQueue();
            else StopDialogue();
        }

        public void PlayDialogue(Dialogue dialogue)
        {
            _dialogueQueue.Enqueue(dialogue);
            if (!aiTalking.Value) FillCharQueue();
        }

        private void FillCharQueue()
        {
            _characterQueue = new Queue<char>();
            LeanTween.scale(speechBubble, Vector3.one, .3f).setEase(speechBubbleTweenType);
            var dialogue = _dialogueQueue.Dequeue();
            dialogueText.text = "";

            foreach (var character in dialogue.dialogueText)
                _characterQueue.Enqueue(character);
            _timePerChar = dialogue.voiceLine
                ? dialogue.voiceLine.clip.length / _characterQueue.Count
                : defaultTimePerChar;

            StopAllCoroutines();
            if (dialogue.voiceLine) playSoundEvent.Raise(dialogue.voiceLine);
            emotionImage.sprite = dialogue.robotEmotion;
            StartCoroutine(nameof(DisplayNextCharacter));
        }

        private IEnumerator DisplayNextCharacter()
        {
            aiTalking.Value = true;
            dialogueText.text += _characterQueue.Dequeue();
            if (_characterQueue.Count % 3 == 0)
                playSoundEvent.Raise(talkingSounds[Random.Range(0, talkingSounds.Length)]);
            yield return new WaitForSeconds(_timePerChar);

            if (_characterQueue.Count > 0)
            {
                StartCoroutine(nameof(DisplayNextCharacter));
            }
            else if (_dialogueQueue.Count > 0)
            {
                yield return new WaitForSeconds(1f);
                FillCharQueue();
            }
            else
            {
                yield return new WaitForSeconds(1f);
                StopDialogue();
            }
        }

        private void StopDialogue()
        {
            aiTalking.Value = false;
            dialogueText.text = "";
            LeanTween.scale(speechBubble, Vector3.zero, .3f).setEase(speechBubbleTweenType);
        }
    }
}