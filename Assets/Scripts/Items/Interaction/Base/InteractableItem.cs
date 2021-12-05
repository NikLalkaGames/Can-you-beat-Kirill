using UnityEngine;

namespace Items.Interaction.Base
{
    public abstract class InteractableItem : MonoBehaviour
    {
        protected string Name;
        
        public int Price;

        protected Collider2D Collider2D;

        protected virtual void Start()
        {
            Name = gameObject.name;

            if (!TryGetComponent(out Collider2D collider2D))
            {
                Debug.LogError("Need to attach collider to gameObject to interact");
            }
            else
            {
                Collider2D = collider2D;
            }
            
        }
    }
}