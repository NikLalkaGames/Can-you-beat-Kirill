using Common.Events;
using Common.Variables;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class Coin : InteractableItem
    {
        [SerializeField] private IntVariable _pickUpValue;

        [SerializeField] private IntVariable _totalCoins;

        [SerializeField] private GameEvent OnCoinPickedUp;

        [SerializeField] private bool _leftAfterPick;

        protected override void OnMouseDown()
        {
            OnCoinPickedUp.Raise();
            _totalCoins.Value += _pickUpValue.Value;
            gameObject.SetActive(_leftAfterPick);
        }
    }
}
