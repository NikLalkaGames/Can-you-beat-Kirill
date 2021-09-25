using UI;
using UnityEngine;
using UnityEngine.UI;

namespace EnemyBehaviour.Health
{
    public class BossHealth : BaseHealth
    {
        #region Fields

        // UI script for changing health
        [SerializeField] private UIHealth uiHealth;
        
        #endregion

        #region Methods
        
        protected override void Start()
        {
            if (uiHealth is null)
            {
                Debug.LogError("You need to bind ghost health bar in field");
            }
            
            base.Start();
            
            // health text UI
            uiHealth.MaxValue = MaxHealth;
            uiHealth.Set(MaxHealth);
        }

        public override void Restore(float amount)
        {
            base.Restore(amount);
            uiHealth.Set(HealthValue);
        }

        public override void Reduce(float amount)
        {
            base.Reduce(amount);
            uiHealth.Set(HealthValue);
            if (HealthValue <= 0) Debug.Log("Boss has been beaten");
        }
        
        
        #endregion
        
        #region Test
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Restore(100);
            }
        }
        
        #endregion
    }
}