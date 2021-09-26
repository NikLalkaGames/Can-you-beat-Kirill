﻿using Common;
using Items;
using Items.Base;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class UIItem : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Item itemType;
        
        private RectTransform _rectTransform;
        private Image _image;
        private Color _originColor;
        private Color _fadedColor;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();

            _originColor = _image.color;
            
            _fadedColor = _image.color;
            _fadedColor.a = 0.6f;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _image.color = _fadedColor;
            
            MovableItem.InstantiateWithCallback(
                MovableItem.GetObjectBy(itemType).GetComponent<MovableItem>(),
                GameManager.Instance.MousePosition, 
                ReturnCallback,
                DestroyCallback);
        }

        private void ReturnCallback()
        {
            _image.color = _originColor;
        }

        private void DestroyCallback()
        {
            Destroy(gameObject);
        }

    }
}