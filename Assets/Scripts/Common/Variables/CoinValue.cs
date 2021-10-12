using Common.Events;
using UnityEngine;

namespace Common.Variables
{
    [CreateAssetMenu(menuName = "Variables/Coin", order = 0)]
    public class CoinValue : IntVariable
    {
        public IntVariable coinPickUpValue;

        public void IncreaseAmount()
        {
            Value += coinPickUpValue.InitialValue;
        }

        public void DecreaseAmount()
        {
            Value -= coinPickUpValue.InitialValue;
        }
        
    }
}