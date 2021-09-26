using System;
using UnityEngine;

namespace Items.Base
{
    public class InteractableItem : MonoBehaviour
    {
        protected string _name;
        
        protected virtual void Start()
        {
            _name = gameObject.name;
            
            if (!TryGetComponent(out Collider2D collider2D)) 
                Debug.LogError("Need to attach collider to gameObject to interact");
        }

        protected virtual void OnMouseUpAsButton()
        {
            // Debug.Log($"MouseUp on {_name}");
        }

        protected virtual void OnMouseDown()
        {
            // Debug.Log($"MouseDown on {_name}");
        }
    }
}