using UnityEngine;

namespace Items.ItemContainer
{
    [CreateAssetMenu(menuName = "Items/ItemCollection")]
    public class ItemCollection : ScriptableObject
    {
        public GameObject[] itemPrefabs;
    }
}