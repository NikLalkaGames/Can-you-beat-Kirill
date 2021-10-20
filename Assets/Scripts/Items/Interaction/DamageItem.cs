using System;
using Common.Containers;
using EnemyBehaviour.Health;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class DamageItem : InteractableByEnemy
    {
        [SerializeField] private float _damageValue;
        
        private void OnEnable()
        {
            transform.SetParent(FoodRuntimeCollection.Instance.transform);
        }
        
        protected override void OnCollision(UnitHealth unitHealth)
        {
            unitHealth.TryToDamage(_damageValue);
            PoolManager.ReleaseObject(gameObject);
            transform.SetParent(PoolManager.Instance.root);
        }
    }
}