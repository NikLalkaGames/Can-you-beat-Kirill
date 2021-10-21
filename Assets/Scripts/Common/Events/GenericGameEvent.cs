using System.Collections.Generic;
using UnityEngine;

namespace Common.Events
{
    [System.Serializable]
    public class GenericGameEvent<T> : ScriptableObject
    {
        private readonly List<GenericGameEventListener<T>> _listeners = new List<GenericGameEventListener<T>>();

        public void Raise(T argument)
        {
            for(int i = _listeners.Count -1; i >= 0; i--)
                _listeners[i].OnEventRaised(argument);
        }

        public void RegisterListener(GenericGameEventListener<T> listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(GenericGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
        
    }
}