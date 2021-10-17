using System;
using EnemyBehaviour.Health;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class HealingItem : InteractableItem
    {
        [SerializeField] private float _healValue;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out UnitHealth unitHealth))
            {
                unitHealth.Restore(_healValue);
                Destroy(gameObject);
                
            }
        }
        
        
    }
}