﻿using UnityEngine;

namespace Items.Interaction
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