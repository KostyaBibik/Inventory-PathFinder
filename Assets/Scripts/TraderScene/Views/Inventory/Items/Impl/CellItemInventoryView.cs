using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TraderScene.Views.Inventory.Items.Impl
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CellItemInventoryView : ItemInventoryView, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Action OnDragStarted;
        public Action OnDragEnd;
        
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private Vector3 _dragOffset;
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public override void UpdateView(string name, string price, Sprite icon = null)
        {
            base.UpdateView(name, price, icon);
            
            _canvasGroup.blocksRaycasts = true;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!IsBusy)
            {
                return;
            }
            
            _dragOffset = _rectTransform.position - (Vector3)eventData.position;
            
            OnDragStarted?.Invoke();
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!IsBusy)
            {
                return;
            }
            
            UpdatePos((Vector3)eventData.position + _dragOffset);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!IsBusy)
            {
                return;
            }
            
            OnDragEnd?.Invoke();
            _canvasGroup.blocksRaycasts = true;
        }

        private void UpdatePos(Vector3 pos)
        {
            _rectTransform.position = pos;
        }
    }
}