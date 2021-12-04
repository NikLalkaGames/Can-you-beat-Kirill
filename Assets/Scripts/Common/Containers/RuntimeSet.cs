using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Containers
{
    [CreateAssetMenu(menuName = "Items/RuntimeSet", order = 0)]
    public class RuntimeSet : ScriptableObject
    {
        public List<Transform> Things;

        protected void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Add(Transform thing)
        {
            if (!Things.Contains(thing))
                Things.Add(thing);
        }

        public void Remove(Transform thing)
        {
            if (Things.Contains(thing))
                Things.Remove(thing);
        }
        
        protected void OnDisable()
        {
            Things.Clear();
        }

        protected void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
        {
            Things.Clear();
        }
    }
}