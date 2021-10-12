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

        protected void Awake()
        {
            Value = InitialValue;
        }

        protected void OnDisable()
        {
            Value = InitialValue;
        }
        
        
    }

}