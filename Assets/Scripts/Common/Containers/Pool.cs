using UnityEngine;

namespace Common.Containers
{
    [CreateAssetMenu(menuName = "Pools/Pool", order = 0)]
    public class Pool : ScriptableObject
    {
        public GameObject Prefab;

        public int Size;
    }
}