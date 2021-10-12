using UnityEngine;

namespace Common.Variables
{
    [CreateAssetMenu(menuName = "Variables/Float", order = 0)]
    public class FloatVariable : ScriptableObject
    {
        public float InitialValue;

        //[NonSerialized]
        public float Value;

        protected void Awake()
        {
            Value = InitialValue;
        }

        protected void OnDestroy()
        {
            Value = InitialValue;
        }
        
        public virtual void SetValue(float value)
        {
            Value = value;
        }

        public virtual void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        public virtual void ApplyChange(float amount)
        {
            Value += amount;
        }

        public virtual void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }
        
    }
    
}