using System;
using Common.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHealth : MonoBehaviour
    {
        [SerializeField] private FloatVariable HP;
        
        [SerializeField] private TextMeshProUGUI tmProComponent;
        
        [SerializeField] private Slider healthBar;

        private void Start()
        {
            healthBar.maxValue = HP.MaxValue;
            tmProComponent.text = $"{HP.MaxValue}/{HP.MaxValue}";
        }

        public void UpdateSlider()
        {
            healthBar.value = HP.Value;
        }

        public void UpdateText()
        {
            tmProComponent.text = $"{HP.Value}/{HP.MaxValue}";
        }

    }
}
