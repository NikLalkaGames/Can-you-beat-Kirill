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
        // constant
        [SerializeField] private float _rotationSpeed;

        [SerializeField] private GameEvent OnItemPlaced;

        private void OnEnable()
        {
            OnItemPlaced.Raise();
        }

        public void OnControlledByPointer(Transform controlledByPointerItem)
        {
            if (Input.mouseScrollDelta.y != 0)
            {
                var currentAngle = controlledByPointerItem.rotation.eulerAngles.z;
                currentAngle += Input.mouseScrollDelta.y * _rotationSpeed;
                controlledByPointerItem.rotation = Quaternion.Euler(0, 0, currentAngle);
            }

        }
    }
}