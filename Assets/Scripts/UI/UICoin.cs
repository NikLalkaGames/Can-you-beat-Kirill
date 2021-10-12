using System;
using Common.Variables;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UICoin : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinUIValue;
        
        [SerializeField] private CoinValue _totalCoins;
        
        public void Start()
        {
            _coinUIValue.text = $"{_totalCoins.InitialValue}";
        }
        
        public void UpdateCoins()
        {
            _coinUIValue.text = $"{_totalCoins.Value}";
        }
    }
}
