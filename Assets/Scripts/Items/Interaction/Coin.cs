using System;
using Common.Containers;
using Common.Events;
using Common.Variables;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class Coin : InteractableItem
    {
        [SerializeField] private IntVariable _totalCoins;

        [SerializeField] private int _coinPickUpValue;

        [SerializeField] private TransformGameEvent OnCoinClicked;

        private void OnMouseDown()
        {
            _totalCoins.Value += _coinPickUpValue;
            
            // coin raise event with positioning
            OnCoinClicked.Raise(transform);
            
            PoolManager.ReleaseObject(gameObject);
        }
    }
}
