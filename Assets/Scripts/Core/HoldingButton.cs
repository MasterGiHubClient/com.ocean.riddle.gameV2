using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Core
{
    public class HoldingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public UnityEvent OnFixedUpdateHolding;

        private bool _isHolding = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isHolding = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isHolding = false;
        }

        private void FixedUpdate()
        {
            if (_isHolding)
            {
                OnFixedUpdateHolding.Invoke();
            }
        }
    }
}