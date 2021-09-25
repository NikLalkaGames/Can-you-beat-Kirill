using EnemyBehaviour.Health;
using UnityEngine;

namespace EnemyBehaviour.Interaction
{
    public class BossInteraction : MonoBehaviour
    {
        [SerializeField] private BossHealth health;

        [SerializeField] private float damageValue;
        
        private void Awake()
        {
            if (health is null) Debug.LogError("Need to attach health script");
        }

        private void Start()
        {
            
        }

        private void OnMouseDown()
        {
            health.Reduce(damageValue);
        }
    }
}