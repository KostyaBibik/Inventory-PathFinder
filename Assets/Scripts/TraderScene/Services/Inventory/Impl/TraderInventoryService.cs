using TraderScene.DataBase.Configs;
using TraderScene.Models.Inventory;
using Zenject;

namespace TraderScene.Services.Inventory.Impl
{
    public class TraderInventoryService : InventoryService, IInitializable
    {
        [Inject] private ItemsPoolConfig _itemsPoolConfig;
        
        public void Initialize()
        {
            FillBaseItems();
        }

        /// <summary>
        /// Populates the trader's inventory with initial items from the configuration.
        /// </summary>
        private void FillBaseItems()
        {
            foreach (var itemConfig in _itemsPoolConfig.Configs)
            {
                var price = itemConfig.Price;
                var name = itemConfig.Name;
                var icon = itemConfig.Icon;

                var item = new ItemModel(name, price, icon);
                AddItem(item);
            }
        }
    }
}