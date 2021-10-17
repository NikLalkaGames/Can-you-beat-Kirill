using Common.Events;
using Items.Interaction.Base;
using Items.Interaction.Base.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Items.Interaction
{
    public class Obstacle : InteractableItem
    {
        [SerializeField] private float _rotationSpeed;

        private float _currentAngle;

        [SerializeField] private GameEvent OnItemPlaced;

        protected override void Start()
        {
            base.Start();
            OnItemPlaced.Raise();
        }
        
        public void PointerAttachedBehaviour() 
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _currentAngle += _rotationSpeed;
                transform.rotation = Quaternion.Euler(0, 0, _currentAngle);
            }

            if (Input.GetKey(KeyCode.E))
            {
                _currentAngle -= _rotationSpeed;
                transform.rotation = Quaternion.Euler(0, 0, _currentAngle);
            }
            
        }
        
        
        

    }
}