using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using CameraLogic;
using Google.Protobuf.WellKnownTypes;
using Items.Interaction.Base;
using Items.Interaction.Base.Interfaces;
using MonsterLove.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Items.Controller
{
    public class ItemController : MonoBehaviour
    {
        #region Fields
        
        #region Singleton
        
        public static ItemController Instance { get; private set; }

        #endregion
        
        #region StateMachine definition

        private enum States
        {
            Wait,
            FollowsTheMouse
        }

        private StateMachine<States, StateDriverUnity> _fsm;
        
        #endregion

        private InteractableItem _itemToPlace;
        
        [SerializeField] private Transform _itemToShow;

        [SerializeField] private SpriteRenderer _itemToShowRenderer;
        
        // UI callbacks
        private Action _returnUiItem;

        private Action _updateUiItem;

        private Action<Transform> _controlledByPointer;
        
        // Constant strings
        private static readonly int _leftMouseButton = 0;

        private static readonly int _rightMouseButton = 1;
        
        #region UI mouse position
        
        // private Canvas _canvas;
        //
        // private Vector2 CanvasMousePosition
        // {
        //     get
        //     {
        //         RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //             (RectTransform) _canvas.transform, 
        //             Input.mousePosition,
        //             null,
        //             out Vector2 mousePosition);
        //
        //         return mousePosition;
        //     }
        // }
        
        #endregion

        #endregion
        
        #region MonoBehaviour Callbacks
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
        
        private void Start()
        {
            ClearCurrentItem();
            
            _fsm = new StateMachine<States, StateDriverUnity>(this);
            
            _fsm.ChangeState(States.Wait);
        }
        
        private void Update()
        {
            _fsm.Driver.Update.Invoke();
        }

        #endregion
        
        #region State Machine implementation

        private void Wait_Enter()
        {
            Debug.Log("Enter 'Wait' state");
        }

        private void FollowsTheMouse_Enter()
        {
            Debug.Log($"{_itemToPlace.name} enters follows the mouse state");
        }

        private void FollowsTheMouse_Update()
        {
            _itemToShow.position = Pointer.Position;
            
            _controlledByPointer?.Invoke(_itemToShow);

            if (Input.GetMouseButtonDown(_leftMouseButton))
            {
                OnLeftMouseButtonDown();
            }
            
            if (Input.GetMouseButtonDown(_rightMouseButton))
            {
                OnRightMouseButtonDown();
            }
        }
        
        #endregion
        
        #region Methods
        
        private void OnLeftMouseButtonDown()
        {
            _updateUiItem.Invoke();
            
            Instantiate(_itemToPlace, Pointer.Position, _itemToShow.rotation);
            
            ClearCurrentItem();

            _fsm.ChangeState(States.Wait);
        }

        private void OnRightMouseButtonDown()
        {
            _returnUiItem.Invoke();

            ClearCurrentItem();
            
            _fsm.ChangeState(States.Wait);
        }

        public void AttachItem(InteractableItem interactableItem, Image itemImage, Action updateItemCallback, Action returnCallback)
        {
            _itemToPlace = interactableItem;
            _updateUiItem = updateItemCallback;
            _returnUiItem = returnCallback;

            if (_itemToPlace is IPointerBehaviour pointerBehaviour)
            {
                _controlledByPointer = pointerBehaviour.OnControlledByPointer; 
            }

            _itemToShowRenderer.sprite = itemImage.sprite;
            _itemToShowRenderer.color = itemImage.color;
            _itemToShow.gameObject.SetActive(true);
            
            _fsm.ChangeState(States.FollowsTheMouse);
        }

        private void ClearCurrentItem()
        {
            _itemToPlace = null;
            _itemToShow.gameObject.SetActive(false);
            _itemToShow.rotation = Quaternion.identity;

            _updateUiItem = null;
            _returnUiItem = null;
            _controlledByPointer = null;
        }
        
        #endregion
        
    }
}