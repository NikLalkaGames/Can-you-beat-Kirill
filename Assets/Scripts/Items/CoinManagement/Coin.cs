using System;
using Items.Base;
using TMPro;
using UnityEngine;

namespace Items.CoinManagement
{
    public class Coin : InteractableItem
    {
        [SerializeField] private int pickUpValue;

        protected override void OnMouseDown()
        {
            CoinManager.Instance.IncreaseAmount(pickUpValue);
            gameObject.SetActive(false);
        }
    }
}
