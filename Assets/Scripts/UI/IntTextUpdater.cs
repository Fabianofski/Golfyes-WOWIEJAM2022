using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace F4B1.UI
{
    public class IntTextUpdater : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        [SerializeField] private string unit;
        
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateText(int value)
        {
            _text.text = value + " " + unit;
        }
    }
}
