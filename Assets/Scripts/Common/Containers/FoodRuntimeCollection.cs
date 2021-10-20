using UnityEngine;

namespace Common.Containers
{
    public class FoodRuntimeCollection : MonoBehaviour
    {
        public static FoodRuntimeCollection Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
    }
}