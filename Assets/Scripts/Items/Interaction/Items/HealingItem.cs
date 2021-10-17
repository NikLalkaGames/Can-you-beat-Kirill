using System;
using EnemyBehaviour.Health;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class HealingItem : InteractableItem
    {
        [SerializeField] private float _healValue;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out UnitHealth unitHealth))
            {
                unitHealth.Restore(_healValue);
                Destroy(gameObject);
            }
        }
    }
}