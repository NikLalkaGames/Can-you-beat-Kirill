using EnemyBehaviour.Health;
using Items.Generation;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class DamageItem : InteractableByEnemy
    {
        [SerializeField] private float _damageValue;
        
        private void OnEnable()
        {
            transform.SetParent(null);
            _itemRuntimeSet.Add(transform);
        }
        
        protected override void OnCollision(UnitHealth unitHealth)
        {
            unitHealth.TryToDamage(_damageValue);
            _itemRuntimeSet.Remove(transform);
            
            PoolManager.ReleaseObject(gameObject);
            transform.SetParent(PoolManager.Instance.root);
        }
    }
}