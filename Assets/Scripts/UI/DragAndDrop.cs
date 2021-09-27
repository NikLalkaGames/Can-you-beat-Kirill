using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Canvas canvas;
        
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;

        private Vector2 _initialPosition;
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();

            _initialPosition = _rectTransform.anchoredPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            _rectTransform.localScale = new Vector3(0.5f, 0.5f, 1);
            _canvasGroup.alpha = 0.6f;
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            
            if (Input.GetButtonDown("Fire2"))
            {
                _rectTransform.localScale = Vector3.one;
                _canvasGroup.alpha = 1f;
                _canvasGroup.blocksRaycasts = true;
                _rectTransform.anchoredPosition = _initialPosition;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }


    }
}