using System;
using EnemyBehaviour.Health;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class DamageItem : InteractableItem
    {
        [SerializeField] private float _damageValue;

        protected void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter OnTriggerEnter state");
            
            if (other.TryGetComponent(out UnitHealth unitHealth))
            {
                unitHealth.TryToDamage(_damageValue);
                Destroy(gameObject);
            }
        }

    }
}