using System;
using Common;
using UnityEngine;

namespace Items.Base
{
    public class MovableItem : InteractableItem
    {
        // TODO: in future change logic to state machine
        
        public Action returnCallback;

        public Action destroyCallback;

        private Transform _transform;

        private bool _followingMouse;
        
        #region Static
        
        public static GameObject GetObjectBy(Item itemType)
        {
            return itemType switch
            {
                Item.PoisonedBurger => Resources.Load("PoisonedBurger") as GameObject,
                Item.Obstacle => Resources.Load("PoisonedBurger") as GameObject,
                Item.DamagePotion => Resources.Load("PoisonedBurger") as GameObject,
                _ => throw new ArgumentException("Item null reference exception or wrong item")
            };
        }

        public static void InstantiateWithCallback(
            MovableItem movableItem, 
            Vector2 position, 
            Action returnCallback,
            Action destroyCallback)
        {
            Instantiate(movableItem, position, Quaternion.identity);
            movableItem.returnCallback = returnCallback;
            movableItem.destroyCallback = destroyCallback;
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
                returnCallback.Invoke();
            }
            
        }

        protected override void OnMouseDown()
        {
            _followingMouse = false;
            destroyCallback.Invoke();
        }
        
    }
}