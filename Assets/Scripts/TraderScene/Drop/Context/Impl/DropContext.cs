using TraderScene.Drop.Handlers;
using TraderScene.Models.Inventory;

namespace TraderScene.Drop.Context.Impl
{
    public class DropContext: IDropContext
    {
        private IDropHandler _currentHandler;

        public void SetHandler(IDropHandler handler)
        {
            _currentHandler = handler;
        }

        public void HandleDrop(ItemModel item)
        {
            _currentHandler?.HandleDrop(item);
        }
    }
}