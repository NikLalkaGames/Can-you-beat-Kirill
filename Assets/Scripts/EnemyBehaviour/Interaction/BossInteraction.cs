using Common.Variables;
using EnemyBehaviour.Health;
using UnityEngine;

namespace EnemyBehaviour.Interaction
{
    public class BossInteraction : MonoBehaviour
    {
        [SerializeField] private UnitHealth _health;

        [SerializeField] private float _damageValue;

        private void Awake()
        {
            if (_health is null) Debug.LogError("Need to attach health script");
        }

        private void Start()
        {
            
        }

        private void OnMouseDown()
        {
            _health.Reduce(_damageValue);
        }
    }
}