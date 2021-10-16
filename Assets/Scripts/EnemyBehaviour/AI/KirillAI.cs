using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Pathfinding;

public class KirillAI : MonoBehaviour
{

    public Transform targetCollection;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float updatePathInterval = 0.5f;
    public float findShortestInterval = 2f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Transform closestTarget;
    float minLength;
    Transform target;
    int remaningTargetsCount;
    float distanceToWaypoint;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, updatePathInterval);
        InvokeRepeating("FindShortest", 0f, findShortestInterval);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void FindShortest()
    {
        minLength = 100000f;
        remaningTargetsCount = targetCollection.childCount;
        foreach (Transform tmp_target in targetCollection)
        {
            RequestManager.RequestPath(rb.position, tmp_target, OnTmpPathComplete);
        }
    }
    void OnTmpPathComplete(Transform tmpTarget, float length)
    {
        remaningTargetsCount--;
        if (length < minLength)
        {
            minLength = length;
            closestTarget = tmpTarget;
        }
        if (remaningTargetsCount == 0)
        {
            target = closestTarget;
        }
    }
    void FixedUpdate()
    {
        if (path == null)
            return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
        }else
        {
            reachedEndOfPath = false;
        }

        if (!reachedEndOfPath)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            distanceToWaypoint = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        }

        if (distanceToWaypoint < nextWaypointDistance && !reachedEndOfPath)
        {
            currentWaypoint++;
        }

    }
}
