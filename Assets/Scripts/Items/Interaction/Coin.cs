using Common.Events;
using Common.Variables;
using Items.Interaction.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Items.Interaction
{
    public class Coin : InteractableItem
    {
        [SerializeField] private IntVariable _totalCoins;

        [SerializeField] private int _coinPickUpValue;
        
        [SerializeField] private bool _leftAfterPick;

        // [SerializeField] private UnityEvent InternalListener;

        protected override void OnMouseDown()
        {
            _totalCoins.Value += _coinPickUpValue;
            
            gameObject.SetActive(_leftAfterPick);
        }
        
        
        
    }
}
