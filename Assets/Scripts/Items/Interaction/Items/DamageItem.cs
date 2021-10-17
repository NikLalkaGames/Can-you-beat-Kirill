using System;
using EnemyBehaviour.Health;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class DamageItem : InteractableByEnemy
    {
        [SerializeField] private float _damageValue;

        protected override void OnCollision(UnitHealth unitHealth)
        {
            unitHealth.TryToDamage(_damageValue);
            PoolManager.ReleaseObject(gameObject);
        }
    }
}