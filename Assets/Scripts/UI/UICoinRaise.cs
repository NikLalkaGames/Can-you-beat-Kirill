using System.Collections;
using Common.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UICoinRaise : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        
        [SerializeField] private Transform _targetTransform;

        [SerializeField] private Image _image;

        private Vector2 _targetPos;

        private Transform _transform;

        [SerializeField] private float _speed;

        [SerializeField] private AudioSource _coinRaiseSound;

        private void Start()
        {
            DeactivateSelf();
            _transform = transform;
            _targetPos = _targetTransform.position;
        }

        public void StartMovement(Transform worldStartTransform)
        {
            ActivateSelf();
            
            StopCoroutine(MoveToTargetRoutine());
            
            _transform.position = RectTransformUtility.WorldToScreenPoint(_camera, worldStartTransform.position);
            
            _coinRaiseSound.Play();
            
            StartCoroutine(MoveToTargetRoutine());
        }

        private IEnumerator MoveToTargetRoutine()
        {
            while (!Helper.Reached(_transform.position, _targetPos))
            {
                yield return new WaitForEndOfFrame();
                _transform.position = Vector2.Lerp(_transform.position, _targetPos, Time.deltaTime * _speed);
            }

            DeactivateSelf();
            yield return null;
        }

        private void ActivateSelf()
        {
            _image.enabled = true;
        }

        private void DeactivateSelf()
        {
            _image.enabled = false;
        }
        
        


    }
}