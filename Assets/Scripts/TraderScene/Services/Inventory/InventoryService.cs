using TraderScene.Models.Inventory;
using UniRx;

namespace TraderScene.Services.Inventory
{
    public abstract class InventoryService
    {
        protected readonly ReactiveCollection<ItemModel> _items = new ReactiveCollection<ItemModel>();
        public IReadOnlyReactiveCollection<ItemModel> Items => _items;

        public virtual void AddItem(ItemModel item) => _items.Add(item);
        public virtual void RemoveItem(ItemModel item) => _items.Remove(item);

        public bool Contains(ItemModel item) => _items.Contains(item);

        public int Count => _items.Count;
    }
}