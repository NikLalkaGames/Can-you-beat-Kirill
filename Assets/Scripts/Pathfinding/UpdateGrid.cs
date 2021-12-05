using UnityEngine;

namespace Pathfinding
{
    public class UpdateGrid : MonoBehaviour
    {
        [SerializeField] private AstarPath _pathfinder;
        
        private Bounds _bounds;

        private void Awake()
        {
            _bounds = new Bounds( Vector3.zero, new Vector3(100, 100) );
        }

        public void UpdateGraph()
        {
            _pathfinder.UpdateGraphs(_bounds);
        }
    }
}