using Common.Events;
using UnityEngine;

namespace Common.Variables
{
    [CreateAssetMenu(menuName = "Variables/Float", order = 0)]
    public class FloatVariable : ScriptableObject
    {
        public float InitialValue;

        public float MaxValue;
        
        [SerializeField]
        private float _value;

        public float Value
        {
            get => _value;
            set
            {
                _value = Mathf.Clamp(value, 0, MaxValue);
                OnValueChanged.Raise();
            }
        }

        public GameEvent OnValueChanged;

        protected void Awake()
        {
            Value = InitialValue;
        }

        protected void OnDisable()
        {
            Value = InitialValue;
        }
        
        protected void OnDestroy()
        {
            Value = InitialValue;
        }

    }
    
}