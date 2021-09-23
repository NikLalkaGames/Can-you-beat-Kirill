using UnityEngine;
using UnityEngine.UI;

namespace EnemyBehaviour.Health
{
    public class BossHealth : BaseHealth
    {
        #region Fields

        // UI for hero ghost
        [SerializeField] private Slider healthBar;
        
        #endregion

        #region Methods
        
        protected override void Start()
        {
            if (healthBar is null)
            {
                Debug.LogError("You need to bind ghost health bar in field");
            }
            
            base.Start();
            healthBar.maxValue = MaxHealth;
            healthBar.value = MaxHealth;
        }

        public override void Restore(float amount)
        {
            base.Restore(amount);
            healthBar.value = HealthValue;
        }

        public override void Reduce(float amount)
        {
            base.Reduce(amount);
            healthBar.value = HealthValue;
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