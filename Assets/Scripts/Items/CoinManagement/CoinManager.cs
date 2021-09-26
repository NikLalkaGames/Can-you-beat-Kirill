using System;
using TMPro;
using UnityEngine;

namespace Items.CoinManagement
{
    public class CoinManager : MonoBehaviour
    {
        #region Singleton Implementation
        
        public static CoinManager Instance { get; private set; } = null;

        private void Awake() 
        {
            Debug.Log("CoinManager Awake");
            if (Instance == null) Instance = this;
        }
        
        #endregion
        
        [SerializeField] private TextMeshProUGUI uiValue;
        
        private int _coinValue = 0;

        private void Start()
        {
            if (uiValue is null) Debug.LogError("Need to attach TMPro text to script");
        }

        public int CoinValue
        {
            get => _coinValue;
            set
            {
                _coinValue = Mathf.Clamp(value, 0, int.MaxValue);
                uiValue.text = $"{_coinValue}";
            }
        }

        public void IncreaseAmount(int valueToIncrease)
        {
            CoinValue += valueToIncrease;
        }

        public void DecreaseAmount(int valueToDecrease)
        {
            CoinValue -= valueToDecrease;
        }
        
    }
}