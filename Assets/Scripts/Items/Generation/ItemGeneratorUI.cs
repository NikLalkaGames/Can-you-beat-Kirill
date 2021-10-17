using Common.Variables;
using Items.Interaction.Base;
using TMPro;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items.Generation
{
    public class ItemGeneratorUI : ItemGenerator
    {
        // total amount of coins
        [SerializeField] private IntVariable _totalCoins;

        // refresh cost
        [SerializeField] private int _refreshCost;
        
        // ui refresh items cost text
        [SerializeField] private TextMeshProUGUI _uiRefreshCost;

        // ui item transforms 
        [SerializeField] private Transform[] uiItemTransforms;
        

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
            var item = GetRandomItem();
            
            uiItemTransform.TryGetComponent(out UIItem uiItem);
            
            uiItem.AttachData(item, UpdateItem);
        }
        
        private InteractableItem GetRandomItem()
        {
            return ItemPrefabs[Random.Range(0, ItemPrefabs.Length)];
        }

        #endregion
    }
}