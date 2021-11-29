using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Containers
{
    [CreateAssetMenu(menuName = "Items/RuntimeSet", order = 0)]
    public class RuntimeSet : ScriptableObject
    {
        public List<Transform> Items;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
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

        private void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
        {
            Items.Clear();
        }
    }
}