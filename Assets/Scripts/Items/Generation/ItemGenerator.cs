using Common.Containers;
using Common.Variables;
using Items.Interaction.Base;
using TMPro;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items.Generation
{
    public class ItemGenerator : MonoBehaviour
    {
        // total amount of coins
        [SerializeField] private IntVariable _totalCoins;

        // refresh cost
        [SerializeField] private int _refreshCost;
        
        // ui refresh items cost text
        [SerializeField] private TextMeshProUGUI _uiRefreshCost;
        
        // collection of all items available for movement in the game 
        [SerializeField] private ItemCollection itemCollection;
        
        // cached available items
        private MovableItem[] _itemPrefabs;
        
        // ui item transforms 
        [SerializeField] private Transform[] uiItemTransforms;
        

        private void Awake()
        {
            _itemPrefabs = itemCollection.ItemPrefabs;
        }

        #region Item changing logic

        private void Start()
        {
            _uiRefreshCost.text = $"{_refreshCost}";
            UpdateItems();
        }
        public void UpdateItemsByPrice()
        {
            if (_totalCoins.Value < _refreshCost) return;

            UpdateItems();
            
            _totalCoins.Value -= _refreshCost;
        }
        
        private void UpdateItems()
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
        
        private MovableItem GenerateRandomItem()
        {
            return _itemPrefabs[Random.Range(0, _itemPrefabs.Length)];
        }

        #endregion
    }
}