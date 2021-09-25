using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHealth : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmProComponent;
        
        [SerializeField] private Slider healthBar;

        private float _maxValue;

        public float MaxValue
        {
            get => _maxValue;
            set
            {   
                _maxValue = value;              // for text
                healthBar.maxValue = value;     // for health bar
            }
        }

        private void Start()
        {
            if (healthBar is null)
            {
                Debug.LogError("You need to bind ghost health bar in field");
            }
        }

        #region Methods

        public void Set(float value)
        {
            healthBar.value = value;
            SetText($"{value}/{MaxValue}");
        }
        
        private void SetText(string text) =>
            tmProComponent.text = text;
        
        #endregion

    }
}
