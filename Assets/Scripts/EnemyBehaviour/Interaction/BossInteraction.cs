using EnemyBehaviour.Health;
using UnityEngine;
using Pathfinding;

namespace EnemyBehaviour.Interaction
{
    public class BossInteraction : MonoBehaviour
    {
        [SerializeField] private BossHealth health;

        [SerializeField] private float damageValue;

        // [SerializeField] private AstarPath pathfinder;

        private Bounds _bounds;
        
        private void Awake()
        {
            if (health is null) Debug.LogError("Need to attach health script");
            _bounds = new Bounds( Vector3.zero, new Vector3(100, 100) );
        }

        private void Start()
        {
            
        }

        private void OnMouseDown()
        {
            health.Reduce(damageValue);
            // pathfinder.UpdateGraphs(_bounds);
        }
    }
}