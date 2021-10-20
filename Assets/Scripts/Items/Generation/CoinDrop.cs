using System;
using Items.Interaction;
using Unity.Mathematics;
using UnityEngine;

namespace Items.Generation
{
    public class CoinDrop : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;

        [SerializeField] private AnimationCurve _animCurve;

        private Transform _coinTransform;

        private Vector2 _startPosition;

        private float _y = 0;

        private float _currentTime;

        private bool _needToDrop;

        private void OnEnable()
        {
            _coinTransform = PoolManager.SpawnObject(_coinPrefab, transform.position, quaternion.identity).transform;

            _startPosition = _coinTransform.position;
            
            _needToDrop = true;
        }

        private void Update()
        {
            if (_needToDrop)
            {
                _currentTime += Time.deltaTime;
                if (_currentTime < _animCurve[_animCurve.keys.Length - 1].time)
                {
                    _y = _animCurve.Evaluate(_currentTime);
                    _coinTransform.position = new Vector3(_startPosition.x, _startPosition.y + _y);
                }
                else
                {
                    _currentTime = 0;
                    _y = 0;
                    _needToDrop = false;
                    this.enabled = false;
                }
            }

        }


    }
}