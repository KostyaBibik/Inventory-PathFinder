using TraderScene.Models.Inventory;
using UniRx;

namespace TraderScene.Services.Inventory
{
    public abstract class InventoryService
    {
        private readonly ReactiveCollection<ItemModel> _items = new ReactiveCollection<ItemModel>();
        public IReadOnlyReactiveCollection<ItemModel> Items => _items;

        public virtual void AddItem(ItemModel item) => _items.Add(item);
        public virtual void RemoveItem(ItemModel item) => _items.Remove(item);
    }
}