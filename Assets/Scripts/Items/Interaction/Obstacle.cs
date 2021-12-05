using System.Collections;
using Common.Events;
using Items.Interaction.Base;
using Items.Interaction.Base.Interfaces;
using UnityEngine;

namespace Items.Interaction
{
    public class Obstacle : InteractableItem, IPointerBehaviour
    {
        // constant
        [SerializeField] private float _rotationSpeed;

        [SerializeField] private GameEvent OnItemPlaced;

        [SerializeField] private float _timeUntilFade;

        [SerializeField] private float _fadeDelta;
        
        private SpriteRenderer _spriteRenderer;

        protected override void Start()
        {
            base.Start();
            TryGetComponent(out SpriteRenderer sr);
            _spriteRenderer = sr;
        }
        
        private void OnEnable()
        {
            OnItemPlaced.Raise();
            StartCoroutine(WaitForFadeOut());
        }

        public void OnControlledByPointer(Transform controlledByPointerItem)
        {
            if (Input.mouseScrollDelta.y != 0)
            {
                var currentAngle = controlledByPointerItem.rotation.eulerAngles.z;
                currentAngle += Input.mouseScrollDelta.y * _rotationSpeed;
                controlledByPointerItem.rotation = Quaternion.Euler(0, 0, currentAngle);
            }

        }

        private IEnumerator WaitForFadeOut()
        {
            yield return new WaitForSeconds(_timeUntilFade);
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            while (_spriteRenderer.color.a > 0)
            {
                yield return new WaitForEndOfFrame();
                var color = _spriteRenderer.color;
                color.a -= _fadeDelta;
                _spriteRenderer.color = color;
            }
            
            PoolManager.ReleaseObject(gameObject);
            OnItemPlaced.Raise();
        }
    }
}