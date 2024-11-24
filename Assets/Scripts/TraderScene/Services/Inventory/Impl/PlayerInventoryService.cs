using TraderScene.DataBase.Configs;
using TraderScene.Models.Inventory;
using Zenject;

namespace TraderScene.Services.Inventory.Impl
{
    public class PlayerInventoryService : InventoryService, IInitializable
    {
        [Inject] private ItemsPoolConfig _itemsPoolConfig;
        
        public void Initialize()
        {
            FillBaseItems();
        }

        private void FillBaseItems()
        {
            foreach (var itemConfig in _itemsPoolConfig.Configs)
            {
                var price = itemConfig.Price;
                var name = itemConfig.Name;
                var icon = itemConfig.Icon;
                var count = itemConfig.Count;

                var item = new ItemModel(name, price, icon, count);
                AddItem(item);
            }
        }
    }
}