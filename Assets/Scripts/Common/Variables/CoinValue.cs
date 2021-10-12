using Common.Events;
using UnityEngine;

namespace Common.Variables
{
    [CreateAssetMenu(menuName = "Variables/Coin", order = 0)]
    public class CoinValue : IntVariable
    {
        public IntVariable coinPickUpValue;

        public void Increase()
        {
            ApplyChange(coinPickUpValue);
        }

        
    }
}