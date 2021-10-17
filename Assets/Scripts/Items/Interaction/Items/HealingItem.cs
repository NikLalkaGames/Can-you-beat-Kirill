using System;
using EnemyBehaviour.Health;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class HealingItem : InteractableByEnemy
    {
        [SerializeField] private float _healValue;
        
        protected override void OnCollision(UnitHealth unitHealth)
        {
            unitHealth.Restore(_healValue);
            PoolManager.ReleaseObject(gameObject);
        }
    }
}