using System;
using Common;
using Items.Base;
using MonsterLove.StateMachine;
using UnityEngine;

namespace Items.Interaction
{
    public class MovableItem : InteractableItem
    {
        #region Fields
        
        #region StateMachine definition

        private enum States
        {
            FollowsTheMouse,
            World
        }

        private StateMachine<States, StateDriverUnity> _fsm;
        
        #endregion

        // UI callbacks
        
        private Action _returnCallback;

        private Action _updateItemCallback;
        
        // Positioning  
        
        private Transform _transform;
        
        #endregion

        #region Base Monobehaviour
        
        protected override void Start()
        {
            base.Start();
            _transform = transform;
            _fsm = new StateMachine<States, StateDriverUnity>(this);
            _fsm.ChangeState(States.FollowsTheMouse);
        }
        
        private void Update()
        {
            _fsm.Driver.Update.Invoke();
        }
        
        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            _fsm.Driver.OnMouseDown.Invoke();
        }

        #endregion
        
        #region State Machine implementation

        private void FollowsTheMouse_Enter()
        {
            Debug.Log($"{_name} enters follows the mouse state");
        }
        
        private void FollowsTheMouse_Update()
        {            
            _transform.position = GameManager.Instance.MousePosition;

            if (Input.GetButtonDown("Fire2"))
            {
                _returnCallback?.Invoke();
                _returnCallback = null;
                Destroy(gameObject);
            }
        }

        private void FollowsTheMouse_OnMouseDown()
        {
            _updateItemCallback?.Invoke();
            _updateItemCallback = null;
            _fsm.ChangeState(States.World);
        }

        private void World_Enter()
        {
            Debug.Log($"{_name} enters world state");
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