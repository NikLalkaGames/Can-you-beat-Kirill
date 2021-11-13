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

        protected void OnEnable()
        {
            transform.SetParent(null);
            _itemRuntimeSet.Add(transform);
        }
        
        // protocol of collision
        protected abstract void OnCollisionEnter2D(Collision2D other);
    }
}