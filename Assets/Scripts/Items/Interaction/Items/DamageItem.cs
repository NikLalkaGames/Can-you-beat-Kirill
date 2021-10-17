using System;
using EnemyBehaviour.Health;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class DamageItem : InteractableItem
    {
        [SerializeField] private float _damageValue;

        protected void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out UnitHealth unitHealth))
            {
                unitHealth.TryToDamage(_damageValue);
                Destroy(gameObject);
            }
        }

    }
}