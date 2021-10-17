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
        
        [SerializeField] private bool _leftAfterPick;

        private void OnMouseDown()
        {
            _totalCoins.Value += _coinPickUpValue;

            if (!_leftAfterPick)
            {
                PoolManager.ReleaseObject(gameObject);
            }
        }
        
        
        
    }
}
