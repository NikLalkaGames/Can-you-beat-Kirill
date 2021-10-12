using UnityEngine;

namespace Items.Interaction.Base
{
    public class InteractableItem : MonoBehaviour
    {
        protected string Name;
        
        protected virtual void Start()
        {
            Name = gameObject.name;
            
            if (!TryGetComponent(out Collider2D collider2D)) 
                Debug.LogError("Need to attach collider to gameObject to interact");
        }

        protected virtual void OnMouseUpAsButton()
        {
            Debug.Log($"MouseUp on {Name}");
        }

        protected virtual void OnMouseDown()
        {
            Debug.Log($"MouseDown on {Name}");
        }
    }
}