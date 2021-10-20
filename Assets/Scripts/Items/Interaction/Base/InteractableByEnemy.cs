using System;
using Common.Containers;
using Common.Events;
using EnemyBehaviour.Health;
using UnityEngine;

namespace Items.Interaction.Base
{
    public abstract class InteractableByEnemy : InteractableItem
    {
        [SerializeField] protected RuntimeSet _itemRuntimeSet; 
        
        protected void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out UnitHealth unitHealth))
            {
                OnCollision(unitHealth);
            }
        }

        protected abstract void OnCollision(UnitHealth unitHealth);
    }
}