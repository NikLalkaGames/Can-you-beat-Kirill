using UnityEngine;

namespace Common.Utils
{
    public class ItemRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        
        private void FixedUpdate()
        {
            transform.RotateAround(transform.position, Vector3.up, _rotationSpeed * Time.fixedDeltaTime);
        }
    }
}