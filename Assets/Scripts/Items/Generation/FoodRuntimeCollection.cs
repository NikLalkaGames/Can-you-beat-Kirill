using Common.Containers;
using Items.Interaction.Base;
using UnityEngine;

namespace Items.Generation
{
    public class FoodRuntimeCollection : MonoBehaviour
    {
        public static FoodRuntimeCollection Instance { get; private set; }

        [SerializeField] private RuntimeSet _foodRuntimeCollection;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }


    }
}