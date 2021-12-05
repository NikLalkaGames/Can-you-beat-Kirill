using UnityEngine;

namespace CameraLogic
{
    // Not used
    public class CamLocator : MonoBehaviour
    {
        public static Transform CamTransform;

        private void Awake()
        {
            CamTransform = transform;
        }
    }
}