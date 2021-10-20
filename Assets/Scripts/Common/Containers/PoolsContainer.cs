using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Containers
{
    [CreateAssetMenu(menuName = "Pools/PoolContainer", order = 0)]
    public class PoolsContainer : ScriptableObject
    {
        public List<Pool> Pools;
    }
}