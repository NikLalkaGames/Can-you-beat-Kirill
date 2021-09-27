using System;
using Common;
using Items.Enum;
using MonsterLove.StateMachine;
using UnityEngine;

namespace Items.Base
{
    public class MovableItem : InteractableItem
    {

        
        // UI callbacks
        
        private Action _returnCallback;

        private Action _clearItemSlotCallback;
        
        // Positioning  
        
        private Transform _transform;
        
        private bool _followingMouse;
        
        #region Static

        // TODO: rename to real items
        private static GameObject GetObjectBy(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.PoisonedBurger => Resources.Load("PoisonedBurger") as GameObject,
                ItemType.Obstacle => Resources.Load("PoisonedBurger") as GameObject,
                ItemType.DamagePotion => Resources.Load("PoisonedBurger") as GameObject,
                _ => throw new ArgumentException("Item null reference exception or wrong item")
            };
        }

        public static MovableItem InstantiateItem(Enum.ItemType itemTypeType)
        {
            GetObjectBy(itemTypeType).TryGetComponent(out MovableItem movableItem);
            return Instantiate(movableItem, GameManager.Instance.MousePosition, Quaternion.identity);
        }
        
        #endregion

        protected override void Start()
        {
            _transform = transform;
            _followingMouse = true;
        }

        private void Update()
        {
            if (!_followingMouse) return;
            
            _transform.position = GameManager.Instance.MousePosition;

            if (Input.GetButtonDown("Fire2"))
            {
                _followingMouse = false;
                Destroy(gameObject);
                _returnCallback?.Invoke();
                _returnCallback = null;
            }
        }

        protected override void OnMouseDown()
        {
            _followingMouse = false;
            _clearItemSlotCallback?.Invoke();
            _clearItemSlotCallback = null;
        }
        
        public void AttachCallbacks(Action returnCallback, Action clearItemSlotCallback)
        {
            _returnCallback = returnCallback;
            _clearItemSlotCallback = clearItemSlotCallback;
        }
    }
}