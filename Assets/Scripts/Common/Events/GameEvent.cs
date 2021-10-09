using System.Collections.Generic;
using UnityEngine;

namespace Common.Events
{
    [CreateAssetMenu(menuName = "Event/GameEvent", order = 0)]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

        public void Raise()
        {
            foreach (var listener in _listeners)
            {
                listener.OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
        
        
    }
}