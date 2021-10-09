using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class RequestManager : MonoBehaviour
{
    Queue<PathRequest> pathRequests = new Queue<PathRequest>();
    PathRequest currentPathRequest;

    static RequestManager instance;
    Seeker seeker;

    bool isProcessingPath;
    void Awake()
    {
        instance = this;
        seeker = GetComponent<Seeker>();
    }

    public static void RequestPath(Vector2 startPos, Transform target, Action<Transform, float>callback)
    {
        PathRequest newRequest = new PathRequest(startPos, target, callback);
        instance.pathRequests.Enqueue(newRequest);
        instance.TryProcessNext();
    }
    void TryProcessNext()
    {
        if(!isProcessingPath && pathRequests.Count > 0)
        {
            currentPathRequest = pathRequests.Dequeue();
            isProcessingPath = true;
            seeker.StartPath(currentPathRequest.startPos, currentPathRequest.target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            currentPathRequest.callback(currentPathRequest.target, p.GetTotalLength());
            isProcessingPath = false;
            TryProcessNext();
        }
    }
    struct PathRequest
    {
        public Vector2 startPos;
        public Transform target;
        public Action<Transform, float> callback;

        public PathRequest(Vector2 _startPos, Transform _target, Action<Transform, float> _callback)
        {
            startPos = _startPos;
            target = _target;
            callback = _callback;
        }
    }
}
