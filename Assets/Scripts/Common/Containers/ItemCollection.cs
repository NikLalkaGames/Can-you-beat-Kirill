using UnityEngine;

namespace Common.Containers
{
    [CreateAssetMenu(menuName = "Items/ItemCollection")]
    public class ItemCollection : ScriptableObject
    {
        public GameObject[] _itemPrefabs;
    }
}