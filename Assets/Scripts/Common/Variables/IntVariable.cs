using System;
using Common.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Variables
{
    [CreateAssetMenu(menuName = "Variables/Int", order = 0)]
    public class IntVariable : ScriptableObject
    {
        public int InitialValue;

        public int MaxValue;
        
        [SerializeField]
        public int _value;

        public int Value
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