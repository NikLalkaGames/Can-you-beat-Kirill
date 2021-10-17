using System;
using Common.Events;
using Items.Interaction.Base;
using Items.Interaction.Base.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Items.Interaction
{
    public class Obstacle : InteractableItem, IPointerBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        private float _currentAngle;

        [SerializeField] private GameEvent OnItemPlaced;

        private void OnEnable()
        {
            OnItemPlaced.Raise();
        }

        public void OnControlledByPointer(Transform controlledByPointerItem) 
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _currentAngle += _rotationSpeed;
                controlledByPointerItem.rotation = Quaternion.Euler(0, 0, _currentAngle);
            }
            if (Input.GetKey(KeyCode.E))
            {
                _currentAngle -= _rotationSpeed;
                controlledByPointerItem.rotation = Quaternion.Euler(0, 0, _currentAngle);
            }
            
        }
        
        
        

    }
}