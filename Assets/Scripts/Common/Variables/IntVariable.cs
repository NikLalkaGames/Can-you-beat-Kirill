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
        
        public int Value;

        public GameEvent OnValueChanged;

        protected void Awake()
        {
            Value = InitialValue;
        }

        protected void OnDisable()
        {
            Value = InitialValue;
        }
        
        public void SetValue(int value)
        {
            Value = value;
            OnValueChanged.Raise();
        }

        public void SetValue(IntVariable value)
        {
            SetValue(value.Value);
        }

        public void ApplyChange(int amount)
        {
            Value += amount;
            OnValueChanged.Raise();
        }

        public void ApplyChange(IntVariable amount)
        {
            ApplyChange(amount.Value);
        }
        
    }

}