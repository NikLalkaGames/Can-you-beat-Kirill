using System.Collections;
using Common.Containers;
using Pathfinding;
using UnityEngine;

namespace EnemyBehaviour.AI
{
    public class KirillAI : MonoBehaviour
    {

        public RuntimeSet targetCollection;
        [SerializeField] private float speed = 200f;
        [SerializeField] private float nextWaypointDistance = 3f;
        [SerializeField] private float updatePathInterval = 0.5f;
        [SerializeField] private float findShortestDelay = 0.5f;

        private Path _path;
        private int _currentWaypoint = 0;
        private bool _reachedEndOfPath = false;
        private Transform _closestTarget;
        private float _minLength;
        private Transform _target;
        private int _remainingTargetsCount;
        private float _distanceToWaypoint;

        private Seeker _seeker;
        private Rigidbody2D _rb;
        
        private void Start()
        {
            _seeker = GetComponent<Seeker>();
            _rb = GetComponent<Rigidbody2D>();

            InvokeRepeating("UpdatePath", 0f, updatePathInterval);

            StartCoroutine(FindShortestWithDelay());
        }

        private IEnumerator FindShortestWithDelay()
        {
            yield return new WaitForSeconds(findShortestDelay);
            FindShortest();
        }

        private void UpdatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
            }
        
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _path = p;
            _currentWaypoint = 0;
        }
    
        public void FindShortest()
        {
            RequestManager.ResetRequests();

            _minLength = Mathf.Infinity;
            _remainingTargetsCount = targetCollection.Things.Count;
            foreach (Transform tmpTarget in targetCollection.Things)
            {
                RequestManager.RequestPath(_rb.position, tmpTarget.transform, OnTmpPathComplete);
            }
        }
    
        private void OnTmpPathComplete(Transform tmpTarget, float length)
        {
            _remainingTargetsCount--;
            if (length < _minLength)
            {
                _minLength = length;
                _closestTarget = tmpTarget;
            }
            if (_remainingTargetsCount == 0)
            {
                _target = _closestTarget;
            }
        }
    
        private void FixedUpdate()
        {
            if (_path == null)
                return;
            if(_currentWaypoint >= _path.vectorPath.Count)
            {
                _reachedEndOfPath = true;
                _rb.velocity = Vector2.zero;
            }
            else
            {
                _reachedEndOfPath = false;
            }

            if (!_reachedEndOfPath)
            {
                Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
                Vector2 force = direction * (speed * Time.deltaTime);

                //rb.AddForce(force);
                _rb.velocity = force;

                _distanceToWaypoint = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);
            }

            if (_distanceToWaypoint < nextWaypointDistance && !_reachedEndOfPath)
            {
                _currentWaypoint++;
            }

        }
    }
}
