using Common.Events;
using EnemyBehaviour.Health;
using Items.Generation;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class HealingItem : InteractableByEnemy
    {
        [SerializeField] private float _healValue;
        
        [SerializeField] private GameEvent OnHealingItemInteracted;

        private void OnEnable()
        {
            transform.SetParent(null);
            
            _itemRuntimeSet.Add(transform);
        }

        protected override void OnCollision(UnitHealth unitHealth)
        {
            unitHealth.Restore(_healValue);
            _itemRuntimeSet.Remove(transform);
            
            PoolManager.ReleaseObject(gameObject);
            transform.SetParent(PoolManager.Instance.root);
            
            OnHealingItemInteracted.Raise();
        }
    }
}