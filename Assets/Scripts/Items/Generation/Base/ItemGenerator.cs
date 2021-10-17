using Common.Containers;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Generation
{
    public abstract class ItemGenerator : MonoBehaviour
    {
        
        // collection of all items available for movement in the game 
        [SerializeField] protected ItemCollection ItemCollection;
        
        // cached available items
        protected InteractableItem[] ItemPrefabs;

        protected virtual void Awake()
        {
            ItemPrefabs = ItemCollection.ItemPrefabs;
        }
    }
}