using System;
using Items.ItemContainer;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items.Interaction
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField] private ItemCollection itemCollection;

        [SerializeField] private Transform[] uiItemTransforms;
        
        private GameObject[] _itemPrefabs;

        private void Awake()
        {
            _itemPrefabs = itemCollection.itemPrefabs;
        }

        #region Item changing logic
        
        private void Start() => UpdateItems();

        public void UpdateItems()
        {
            foreach (var itemTransform in uiItemTransforms)
            {
                UpdateItem(itemTransform);
            }
        }

        public void UpdateItem(Transform uiItemTransform)
        {
            var item = GenerateRandomItem();
            
            uiItemTransform.TryGetComponent(out UIItem uiItem);
            uiItem.AttachData(item, UpdateItem);
        }
        
        private GameObject GenerateRandomItem()
        {
            return _itemPrefabs[Random.Range(0, _itemPrefabs.Length)];
        }

        #endregion
    }
}