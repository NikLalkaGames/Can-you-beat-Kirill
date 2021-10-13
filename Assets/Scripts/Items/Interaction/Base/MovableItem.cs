using System;
using Common.Events;
using Common.GameManagement;
using MonsterLove.StateMachine;
using UnityEngine;

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
        
        [SerializeField] protected GameEvent OnItemPlaced;
        
        // Positioning  
        
        protected Transform Transform;
        
        // item price

        public int Price;
        
        #endregion

        #region Base Monobehaviour
        
        protected override void Start()
        {
            base.Start();
            Transform = transform;
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
            Debug.Log($"{Name} enters follows the mouse state");
        }
        
        protected void FollowsTheMouse_Update()
        {            
            Transform.position = GameManager.Instance.MousePosition;

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
            Debug.Log($"{Name} enters world state");
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