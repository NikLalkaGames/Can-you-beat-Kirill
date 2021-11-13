using System;
using UnityEngine;

namespace EnemyBehaviour.AI
{
    public struct PathRequest
    {
        public Vector2 StartPos;
        public readonly Transform Target;
        public readonly Action<Transform, float> Callback;

        public PathRequest(Vector2 startPos, Transform target, Action<Transform, float> callback)
        {
            StartPos = startPos;
            Target = target;
            Callback = callback;
        }
    }
}