using UnityEngine;
using UnityEngine.Events;

namespace Common.Events
{
    [System.Serializable]
    public class GenericGameEventListener<T> : MonoBehaviour
    {
        [SerializeField] protected GenericGameEvent<T> _gameEvent;
        [SerializeField] protected UnityEvent<T> Response;

        protected void OnEnable()
        {
            _gameEvent.RegisterListener(this);
        }

        public void OnEventRaised(T argument)
        {
            Response.Invoke(argument);
        }
        
        protected void OnDisable()
        {
            _gameEvent.UnregisterListener(this);
        }
    }
}