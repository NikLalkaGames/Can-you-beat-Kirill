using System;
using EnemyBehaviour.Health;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class MovableDamage : MovableItem
    {
        [SerializeField] private float _damageValue;

        protected override void World_OnTriggerEnter2D(Collider2D other)
        {
            base.World_OnTriggerEnter2D(Collider2D);
            
            Debug.Log("Enter OnTriggerEnter state");
            
            if (other.TryGetComponent(out UnitHealth unitHealth))
            {
                unitHealth.TryToDamage(_damageValue);
                Destroy(gameObject);
            }
        }
    }
}