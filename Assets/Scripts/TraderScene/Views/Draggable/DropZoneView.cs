using TraderScene.Drop.Context;
using TraderScene.Services.Draggable;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TraderScene.Views.Draggable
{
    public class DropZoneView: MonoBehaviour, IDropHandler
    {
        [Inject] private IDropContext _dropContext;
        [Inject] private DragItemService _dragItemService;
        
        public void OnDrop(PointerEventData eventData)
        {
            var draggableItem = _dragItemService.CurrentDraggableItem.Value;
            if (draggableItem != null)
            {
                _dropContext.HandleDrop(draggableItem);
            }
        }
    }
}