using System;
using Common.Variables;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class Coin : InteractableItem
    {
        [SerializeField] private IntVariable _totalCoins;

        [SerializeField] private int _coinPickUpValue;

        private void OnMouseDown()
        {
            _totalCoins.Value += _coinPickUpValue;
            
            PoolManager.ReleaseObject(gameObject);
        }

        private void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, 1f);
        }
    }
}
