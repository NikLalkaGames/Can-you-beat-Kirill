using System;
using CameraLogic;
using Common.Events;
using Common.GameManagement;
using MonsterLove.StateMachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Items.Interaction.Base
{
    public class MovableItem : InteractableItem
    {
        #region Fields
        
        #region StateMachine definition

        protected enum States
        {
            FollowsTheMouse,
            World
        }

        protected StateMachine<States, StateDriverUnity> Fsm;
        
        #endregion

        // UI callbacks
        private Action _returnCallback;

        private Action _updateItemCallback;

        // Positioning  
        protected Transform Transform;
        
        // item price
        public int Price;
        
        // Constant strings
        private static readonly int _leftMouseButton = 0;

        private static readonly int _rightMouseButton = 1;

        #endregion

        #region Base Monobehaviour
        
        protected override void Start()
        {
            base.Start();
            Transform = transform;
            Fsm = new StateMachine<States, StateDriverUnity>(this);
            
            Fsm.ChangeState(States.FollowsTheMouse);
        }
        
        protected virtual void Update()
        {
            Fsm.Driver.Update.Invoke();
        }
        
        protected override void OnMouseDown()
        {
            Fsm.Driver.OnMouseDown.Invoke();
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            Fsm.Driver.OnTriggerEnter2D.Invoke(Collider2D);
        }

        #endregion
        
        #region State Machine implementation

        protected void FollowsTheMouse_Enter()
        {
            Debug.Log($"{Name} enters follows the mouse state");
        }
        
        protected virtual void FollowsTheMouse_Update()
        {
            Transform.position = Pointer.Position;

            if (Input.GetMouseButtonDown(_leftMouseButton))
            {
                OnLeftMouseButtonDown();
            }

            if (Input.GetMouseButtonDown(_rightMouseButton))
            {
                OnRightMouseButtonDown();
            }
            
        }

        protected void World_Enter()
        {
            Debug.Log($"{Name} enters world state");
        }

        protected virtual void World_OnTriggerEnter2D(Collider2D collider2D)
        {
            
        }
        
        #endregion

        #region Inheritance Callbacks

        protected virtual void OnLeftMouseButtonDown()
        {
            Debug.Log("Item placed");

            _updateItemCallback.Invoke();
            _updateItemCallback = null;
            
            Fsm.ChangeState(States.World);
        }

        protected virtual void OnRightMouseButtonDown()
        {
            _returnCallback.Invoke();
            _returnCallback = null;
                
            Destroy(gameObject);
        }

        #endregion
        
        #region External Methods
        
        public void AttachCallbacks(Action returnCallback, Action updateItemCallback)
        {
            _returnCallback = returnCallback;
            _updateItemCallback = updateItemCallback;
        }

        #endregion
        
    }
}