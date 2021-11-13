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

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out UnitHealth unitHealth))
            {
                unitHealth.Restore(_healValue);
                _itemRuntimeSet.Remove(transform);
                onItemRemoved.Raise();

                PoolManager.ReleaseObject(gameObject);
                transform.SetParent(PoolManager.Instance.root);
            }
            

        }
    }
}