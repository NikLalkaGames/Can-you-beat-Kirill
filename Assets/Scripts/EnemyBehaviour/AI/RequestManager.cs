using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace EnemyBehaviour.AI
{
    public class RequestManager : MonoBehaviour
    {
        private readonly Queue<PathRequest> _pathRequests = new Queue<PathRequest>();
        private PathRequest _currentPathRequest;

        public static RequestManager Instance;
        private Seeker _seeker;

        private bool _isProcessingPath;

        private void Awake()
        {
            Instance = this;
            _seeker = GetComponent<Seeker>();
        }

        public static void ResetRequests()
        {
            Instance._pathRequests.Clear();
        }

        public static void RequestPath(Vector2 startPos, Transform target, Action<Transform, float>callback)
        {
            PathRequest newRequest = new PathRequest(startPos, target, callback);
            Instance._pathRequests.Enqueue(newRequest);
            Instance.TryProcessNext();
        }
        
        private void TryProcessNext()
        {
            if (_isProcessingPath || _pathRequests.Count <= 0) return;
            _currentPathRequest = _pathRequests.Dequeue();
            _isProcessingPath = true;
            _seeker.StartPath(_currentPathRequest.StartPos, _currentPathRequest.Target.position, OnPathComplete);
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _currentPathRequest.Callback(_currentPathRequest.Target, p.GetTotalLength());
            _isProcessingPath = false;
            TryProcessNext();
        }


    }
}
