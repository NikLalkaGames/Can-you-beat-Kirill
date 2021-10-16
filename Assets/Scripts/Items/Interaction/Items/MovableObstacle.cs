using Common.Events;
using Items.Interaction.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Items.Interaction
{
    public class MovableObstacle : MovableItem
    {
        [SerializeField] protected GameEvent OnObstaclePlaced;
        
        [SerializeField] private float _rotationSpeed;

        private float _currentAngle;

        [SerializeField] private UnityEvent OnItemPlaced;

        protected override void FollowsTheMouse_Update() 
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _currentAngle += _rotationSpeed;
                Transform.rotation = Quaternion.Euler(0, 0, _currentAngle);
            }

            if (Input.GetKey(KeyCode.E))
            {
                _currentAngle -= _rotationSpeed;
                Transform.rotation = Quaternion.Euler(0, 0, _currentAngle);
            }
            
            base.FollowsTheMouse_Update();
        }

        protected override void OnLeftMouseButtonDown()
        {
            base.OnLeftMouseButtonDown();
            if (OnObstaclePlaced != null) OnObstaclePlaced.Raise();
            OnItemPlaced?.Invoke();
        }
        
        
        

    }
}