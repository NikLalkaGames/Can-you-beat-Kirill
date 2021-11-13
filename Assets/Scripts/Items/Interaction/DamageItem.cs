using EnemyBehaviour.Health;
using Items.Generation;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Interaction
{
    public class DamageItem : InteractableByEnemy
    {
        [SerializeField] private float _damageValue;

        protected override void OnEnable()
        {
            base.OnEnable();
            onItemRemoved.Raise();
        }
        
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out UnitHealth unitHealth))
            {
                unitHealth.TryToDamage(_damageValue);
                _itemRuntimeSet.Remove(transform);
                onItemRemoved.Raise();

                PoolManager.ReleaseObject(gameObject);
                transform.SetParent(PoolManager.Instance.root);
            }
            
        }
    }
}