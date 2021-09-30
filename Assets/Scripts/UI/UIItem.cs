using System;
using Common;
using Items.Base;
using Items.Interaction;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class UIItem : MonoBehaviour, IPointerDownHandler
    {
        // Item Data scriptable object reference
        public GameObject itemPrefab;

        // ui item sprite values
        private Image _image;
        private Color _originColor;
        private Color _fadedColor;

        private Action<Transform> _updateItemCallback;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void AttachData(GameObject item, Action<Transform> updateItem)
        {
            itemPrefab = item;
            
            itemPrefab.TryGetComponent(out SpriteRenderer sr);
            _image.sprite = sr.sprite;
            _image.color =  sr.color;                   
            _originColor = _image.color;                
            
            _fadedColor = _originColor;
            _fadedColor.a = 0.6f;

            _updateItemCallback ??= updateItem;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _image.color = _fadedColor;

            var item = Instantiate(itemPrefab, GameManager.Instance.MousePosition, Quaternion.identity);
            item.TryGetComponent(out MovableItem movableItem);
            movableItem.AttachCallbacks(ReturnItem, UpdateItem);
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