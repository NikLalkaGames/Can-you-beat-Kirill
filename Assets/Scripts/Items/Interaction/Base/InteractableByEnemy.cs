using System;
using EnemyBehaviour.Health;
using UnityEngine;

namespace Items.Interaction.Base
{
    public abstract class InteractableByEnemy : InteractableItem
    {
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