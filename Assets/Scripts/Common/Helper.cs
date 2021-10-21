using UnityEngine;

namespace Common
{
    public static class Helper
    {
        public static Vector3 GetRandomDir()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

        public static bool Reached(Vector3 currentPosition, Vector3 targetPosition) =>
            Vector2.Distance(currentPosition, targetPosition) < 1e-1;

        public static float ParabolaFunc(float x, float width)
        {
            return  width * Mathf.Pow(x, 2);
        }
        
        public static float InversedParabolaFunc(float x, float width)
        {
            return -width * Mathf.Pow(x, 2);
        }
    }
}