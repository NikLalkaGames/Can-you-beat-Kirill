using UnityEngine;

namespace Common.Variables
{
    [CreateAssetMenu(menuName = "Variables/Float", order = 0)]
    public class FloatVariable : ScriptableObject
    {
        public float InitialValue;

        //[NonSerialized]
        public float Value;

        private void Awake()
        {
            Value = InitialValue;
        }

        private void OnDestroy()
        {
            Value = InitialValue;
        }
    }
    
}