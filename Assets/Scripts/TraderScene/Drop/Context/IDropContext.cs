using TraderScene.Drop.Handlers;
using TraderScene.Models.Inventory;

namespace TraderScene.Drop.Context
{
    public interface IDropContext
    {
        void SetHandler(IDropHandler handler);
        void HandleDrop(ItemModel item);
    }
}