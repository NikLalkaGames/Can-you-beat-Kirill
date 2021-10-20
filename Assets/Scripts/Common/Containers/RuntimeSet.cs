using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Containers
{
    [CreateAssetMenu(menuName = "Items/RuntimeSet", order = 0)]
    public class RuntimeSet : ScriptableObject
    {
        public List<Transform> Items;

        private void OnEnable()
        {
            Items.Clear();
        }

        public void Add(Transform thing)
        {
            if (!Items.Contains(thing))
                Items.Add(thing);
        }

        public void Remove(Transform thing)
        {
            if (Items.Contains(thing))
                Items.Remove(thing);
        }
        
        private void OnDisable()
        {
            Items.Clear();
        }
    }
}