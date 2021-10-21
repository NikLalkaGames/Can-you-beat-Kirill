using System;
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

        [SerializeField] private float _rotationSpeed;

        [SerializeField] private TransformGameEvent OnCoinClicked; 

        private void OnMouseDown()
        {
            _totalCoins.Value += _coinPickUpValue;
            
            OnCoinClicked.Raise(transform);
            
            PoolManager.ReleaseObject(gameObject);
        }

        private void FixedUpdate()
        {
            transform.RotateAround(transform.position, Vector3.up, _rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
