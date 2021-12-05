using Common.Containers;
using UnityEngine;

namespace Items.Generation
{
    public class PoolInitializer : MonoBehaviour
    {
        [SerializeField] private PoolsContainer _pools;

        private void Start()
        {
            foreach (var poolModel in _pools.Pools)
            {
                PoolManager.WarmPool(poolModel.Prefab, poolModel.Size);
            }
        }
        
        
    }
}
