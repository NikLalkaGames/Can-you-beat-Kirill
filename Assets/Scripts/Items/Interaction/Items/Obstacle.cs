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

        [SerializeField] private GameEvent OnItemPlaced;

        private void OnEnable()
        {
            OnItemPlaced.Raise();
        }

        public void OnControlledByPointer(Transform controlledByPointerItem)
        {
            var currentAngle= controlledByPointerItem.rotation.eulerAngles.z;
            
            if (Input.GetKey(KeyCode.Q))
            {
                currentAngle += _rotationSpeed;
                controlledByPointerItem.rotation = Quaternion.Euler(0, 0, currentAngle);
            }
            if (Input.GetKey(KeyCode.E))
            {
                currentAngle -= _rotationSpeed;
                controlledByPointerItem.rotation = Quaternion.Euler(0, 0, currentAngle);
            }
            
        }
    }
}