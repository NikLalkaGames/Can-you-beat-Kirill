using Items.Interaction.Base;
using UnityEngine;

namespace Common.Containers
{
    [CreateAssetMenu(menuName = "Items/ItemCollection")]
    public class ItemCollection : ScriptableObject
    {
        public InteractableItem[] ItemPrefabs;
    }
}