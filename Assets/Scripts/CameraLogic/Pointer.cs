using System;
using UnityEngine;

namespace CameraLogic
{
    public class Pointer : MonoBehaviour
    {
        private static Camera _cam;
        
        public static Vector2 Position => _cam.ScreenToWorldPoint(Input.mousePosition);

        public static bool IsBusy;

        private void Awake()
        {
            _cam = Camera.main;
        }
    }
}