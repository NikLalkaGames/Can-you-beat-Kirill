using Common.Events;
using Common.Variables;
using UnityEngine;

namespace EnemyBehaviour.Health
{
    public class UnitHealth : MonoBehaviour
    {
        # region Variables
        
        #region HealthValues
        
        [SerializeField] private FloatVariable HP;
        
        #endregion
        
        #region Statuses
        
        [Tooltip("Reduces the total damage taken by this number (min of 1)")]
        public float defense = 0;
        
        [Tooltip("Doesn't die when reaching 0 health")]
        public bool immortal = false;

        #endregion
        
        #region Invincible timer
        
        public float timeInvincible = 1f;
        
        private float _invincibleTimer;

        #endregion
        
        #region OnHealthRestored

        [SerializeField] private GameEvent OnHealthRestored;

        [SerializeField] private GameEvent OnHealthReduced;
        
        #endregion

        #endregion
        
        # region Methods

        protected void Start() => HP.Value = HP.MaxValue;

        public void Restore(float amount)
        {
            HP.Value += amount;
            
            if (OnHealthRestored != null)
                OnHealthRestored.Raise();
        }
        
        public void TryToDamage(float amount)
        {
            if (_invincibleTimer >= 0) return;

            var damage = Mathf.Clamp(amount - defense, 0f, Mathf.Infinity);
            Reduce(damage);
            
            _invincibleTimer = timeInvincible;
        }

        public void Reduce(float amount)
        {
            HP.Value -= amount;
            
            if (OnHealthReduced != null)
                OnHealthReduced.Raise();
        }

        protected void FixedUpdate()
        {
            if (_invincibleTimer >= 0) _invincibleTimer -= Time.fixedDeltaTime;
        }

        # endregion
        
    }
}