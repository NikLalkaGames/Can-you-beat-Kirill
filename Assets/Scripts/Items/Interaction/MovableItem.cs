using System;
using Common;
using Common.Events;
using Common.GameManagement;
using Items.Base;
using MonsterLove.StateMachine;
using UnityEngine;

namespace Items.Interaction
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
        
        [SerializeField] protected GameEvent OnItemPlaced;
        
        // Positioning  
        
        protected Transform _transform;
        
        #endregion

        #region Base Monobehaviour
        
        protected override void Start()
        {
            base.Start();
            _transform = transform;
            Fsm = new StateMachine<States, StateDriverUnity>(this);
            Fsm.ChangeState(States.FollowsTheMouse);
        }
        
        protected void Update()
        {
            Fsm.Driver.Update.Invoke();
        }
        
        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            Fsm.Driver.OnMouseDown.Invoke();
        }

        #endregion
        
        #region State Machine implementation

        protected void FollowsTheMouse_Enter()
        {
            Debug.Log($"{_name} enters follows the mouse state");
        }
        
        protected void FollowsTheMouse_Update()
        {            
            _transform.position = GameManager.Instance.MousePosition;

            if (Input.GetButtonDown("Fire2"))
            {
                _returnCallback?.Invoke();
                _returnCallback = null;
                Destroy(gameObject);
            }
        }

        protected void FollowsTheMouse_OnMouseDown()
        {
            Debug.Log("Item placed");
            
            if (OnItemPlaced != null) OnItemPlaced.Raise();
            
            _updateItemCallback?.Invoke();
            _updateItemCallback = null;
            Fsm.ChangeState(States.World);
        }

        protected void World_Enter()
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