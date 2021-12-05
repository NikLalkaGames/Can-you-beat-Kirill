using Common.Containers;
using Common.Events;
using UnityEngine;

namespace Items.Interaction.Base
{
    public abstract class InteractableByEnemy : InteractableItem
    {
        [SerializeField] protected RuntimeSet _itemRuntimeSet;
        
        public GameEvent onItemRemoved;

        private Transform _transform;
        
        protected virtual void OnEnable()
        {
            _transform = transform;
            _transform.SetParent(null);
            _itemRuntimeSet.Add(_transform);
        }
        
        // protocol of collision
        protected abstract void OnCollisionEnter2D(Collision2D other);
    }
}