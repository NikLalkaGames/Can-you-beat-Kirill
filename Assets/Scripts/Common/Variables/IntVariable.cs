using System;
using UnityEngine;

namespace Common.Variables
{
    [CreateAssetMenu(menuName = "Variables/Int", order = 0)]
    public class IntVariable : ScriptableObject
    {
        public int InitialValue;

        //[NonSerialized]
        public int Value;

        private void Awake()
        {
            Value = InitialValue;
        }

        private void OnDisable()
        {
            Value = InitialValue;
        }
        
        
    }

}