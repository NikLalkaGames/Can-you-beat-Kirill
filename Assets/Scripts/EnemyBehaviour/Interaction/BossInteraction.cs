using Common.Variables;
using EnemyBehaviour.Health;
using Items.Generation;
using UnityEngine;

namespace EnemyBehaviour.Interaction
{
    public class BossInteraction : MonoBehaviour
    {
        [SerializeField] private UnitHealth _health;

        [SerializeField] private float _damageValue;

        [SerializeField] private CoinDrop _coinDrop;

        [SerializeField] private FloatVariable _clicksToDrop;

        private float _clicksToDropCache;

        private int _numberOfClicks; 

        private void Awake()
        {
            if (_health is null) Debug.LogError("Need to attach health script");
            _clicksToDropCache = _clicksToDrop.Value;
        }

        private void OnMouseDown()
        {
            _numberOfClicks++;
            _health.Reduce(_damageValue);

            if (_numberOfClicks % _clicksToDropCache == 0)
            {
                _coinDrop.enabled = true;
            }
        }
        

    }
}