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
        public GameEvent onItemRemoved;

        protected void OnEnable()
        {
            transform.SetParent(null);
            _itemRuntimeSet.Add(transform);
        }
        
        // protocol of collision
        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (onItemRemoved != null) onItemRemoved.Raise();
        }
    }
}