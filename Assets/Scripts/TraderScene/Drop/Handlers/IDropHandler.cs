using TraderScene.Models.Inventory;

namespace TraderScene.Drop.Handlers
{
    public interface IDropHandler
    {
        void HandleDrop(ItemModel item);
    }
}