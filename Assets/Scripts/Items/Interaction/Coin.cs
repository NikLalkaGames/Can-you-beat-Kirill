using Common.Events;
using Common.Variables;
using Items.Interaction.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Items.Interaction
{
    public class Coin : InteractableItem
    {
        [SerializeField] private CoinValue _totalCoins;

        [SerializeField] private GameEvent OnCoinPickedUp;

        [SerializeField] private bool _leftAfterPick;

        // [SerializeField] private UnityEvent InternalListener;

        protected override void OnMouseDown()
        {
            _totalCoins.IncreaseAmount();
            
            OnCoinPickedUp.Raise();
            
            gameObject.SetActive(_leftAfterPick);
        }
        
        
        
    }
}
