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
        private MovableItem _itemPrefab;

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

        public void AttachData(MovableItem itemPrefab, Action<Transform> updateItem)
        {
            _itemPrefab = itemPrefab;
            
            _itemPrefab.TryGetComponent(out SpriteRenderer sr);
            _image.sprite = sr.sprite;
            _image.color =  sr.color;                   
            _originColor = _image.color;                
            
            _fadedColor = _originColor;
            _fadedColor.a = 0.6f;

            _updateItemCallback ??= updateItem;
            
            _itemPrice.text = $"{_itemPrefab.Price}";
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_totalCoins.Value < _itemPrefab.Price) return;
            
            _image.color = _fadedColor;

            var runtimeMovableItem = Instantiate(_itemPrefab, GameManager.Instance.MousePosition, Quaternion.identity);
            runtimeMovableItem.AttachCallbacks(ReturnItem, UpdateItem);
        }

        private void ReturnItem()
        {
            _image.color = _originColor;
        }

        private void UpdateItem()
        {
            _totalCoins.Value -= _itemPrefab.Price;
            _updateItemCallback?.Invoke(transform);
        }

        private void OnDisable()
        {
            _updateItemCallback = null;
        }
    }
}