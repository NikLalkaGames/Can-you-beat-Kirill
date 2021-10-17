using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using CameraLogic;
using Google.Protobuf.WellKnownTypes;
using Items.Interaction.Base;
using MonsterLove.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Items.Controller
{
    public class ItemController : MonoBehaviour
    {
        #region Fields
        
        public static ItemController Instance { get; private set; }

        #region StateMachine definition

        private enum States
        {
            Wait,
            FollowsTheMouse
        }

        private StateMachine<States, StateDriverUnity> _fsm;
        
        #endregion

        private InteractableItem _itemToPlace;
        
        [SerializeField] private RectTransform _itemToShow;

        [SerializeField] private Image _itemToShowImage;
        
        // UI callbacks
        private Action _returnCallback;

        private Action _updateItemCallback;
        
        // Constant strings
        private static readonly int _leftMouseButton = 0;

        private static readonly int _rightMouseButton = 1;
        
        // positioning

        [SerializeField] private Canvas _canvas;

        private Vector2 CanvasMousePosition
        {
            get
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    (RectTransform) _canvas.transform, 
                    Input.mousePosition,
                    null,
                    out Vector2 mousePosition);

                return mousePosition;
            }
        }
        
        #endregion
        
        #region MonoBehaviour Callbacks
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
        
        private void Start()
        {
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
            _itemToShow.anchoredPosition = CanvasMousePosition;

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
            Debug.Log("Item placed");

            _updateItemCallback.Invoke();
            
            Instantiate(_itemToPlace, Pointer.Position, Quaternion.identity);
            
            ClearCurrentItem();

            _fsm.ChangeState(States.Wait);
        }

        private void OnRightMouseButtonDown()
        {
            _returnCallback.Invoke();

            ClearCurrentItem();
            
            _fsm.ChangeState(States.Wait);
        }

        public void AttachItem(InteractableItem interactableItem, Image itemImage, Action updateItemCallback, Action returnCallback)
        {
            _itemToPlace = interactableItem;
            _updateItemCallback = updateItemCallback;
            _returnCallback = returnCallback;

            _itemToShowImage.sprite = itemImage.sprite;
            _itemToShowImage.color = itemImage.color;
            _itemToShowImage.SetNativeSize();
            _itemToShow.gameObject.SetActive(true);
            
            _fsm.ChangeState(States.FollowsTheMouse);
        }

        private void ClearCurrentItem()
        {
            _itemToShowImage.sprite = null;
            _itemToPlace = null;
            _itemToShow.gameObject.SetActive(false);
            
            _updateItemCallback = null;
            _returnCallback = null;
        }
        
        #endregion
        
    }
}