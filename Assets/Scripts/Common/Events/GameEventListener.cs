using UnityEngine;
using UnityEngine.Events;

namespace Common.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] protected GameEvent _gameEvent;
        [SerializeField] protected UnityEvent Response;

        protected void OnEnable()
        {
            _gameEvent.RegisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
        
        protected void OnDisable()
        {
            _gameEvent.UnregisterListener(this);
        }
    }
}