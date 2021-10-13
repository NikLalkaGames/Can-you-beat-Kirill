using System;
using Common;
using Common.GameManagement;
using Common.Variables;
using Items.Interaction;
using Items.Interaction.Base;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class UIItem : MonoBehaviour, IPointerDownHandler
    {
        // MovableItem component reference reference
        [NonSerialized] private MovableItem _movableItem;

        // ui item sprite values
        private Image _image;
        private Color _originColor;
        private Color _fadedColor;
        
        // total amount of coins
        [SerializeField] private IntVariable _totalCoins;
        
        // ui item price transform;
        [SerializeField] private TextMeshProUGUI _itemPrice;

        private Action<Transform> _updateItemCallback;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void AttachData(MovableItem item, Action<Transform> updateItem)
        {
            _movableItem = item;
            
            _movableItem.TryGetComponent(out SpriteRenderer sr);
            _image.sprite = sr.sprite;
            _image.color =  sr.color;                   
            _originColor = _image.color;                
            
            _fadedColor = _originColor;
            _fadedColor.a = 0.6f;

            _updateItemCallback ??= updateItem;
            
            _itemPrice.text = $"{_movableItem.Price}";
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_totalCoins.Value < _movableItem.Price) return;

            _totalCoins.Value -= _movableItem.Price;
            _image.color = _fadedColor;

            Instantiate(_movableItem, GameManager.Instance.MousePosition, Quaternion.identity);
            _movableItem.AttachCallbacks(ReturnItem, UpdateItem);
        }

        private void ReturnItem()
        {
            _image.color = _originColor;
        }

        private void UpdateItem()
        {
            _updateItemCallback?.Invoke(transform);
        }

        private void OnDisable()
        {
            _updateItemCallback = null;
        }
    }
}