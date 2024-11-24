using TraderScene.Models.Inventory;
using UniRx;

namespace TraderScene.Services.Draggable
{
    public class DragItemService
    {
        private readonly ReactiveProperty<ItemModel> _currentDraggableItem = new ReactiveProperty<ItemModel>();

        public IReadOnlyReactiveProperty<ItemModel> CurrentDraggableItem => _currentDraggableItem;
        
        public void SetDraggableItem(ItemModel itemModel)
        {
            _currentDraggableItem.Value = itemModel;
        }
    }
}