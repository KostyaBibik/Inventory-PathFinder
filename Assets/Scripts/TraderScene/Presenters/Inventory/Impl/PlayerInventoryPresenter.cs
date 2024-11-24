using System.Linq;
using TraderScene.Drop;
using TraderScene.Models.Inventory;
using TraderScene.Services.Inventory.Impl;
using TraderScene.Views.Inventory.Windows.Impl;
using Zenject;

namespace TraderScene.Presenters.Inventory.Impl
{
    public class PlayerInventoryPresenter : InventoryPresenter<PlayerInventoryWindow, PlayerInventoryService>
    {
        [Inject] private DropContextSwitcher _dropContextSwitcher;
        
        public PlayerInventoryPresenter(
            PlayerInventoryWindow window,
            PlayerInventoryService inventoryService
        ) : base(window, inventoryService)
        {
        }

        protected override void UpdateView()
        {
            Window.UpdateContent(InventoryService.Items.ToList());
            SwitchItemsLayoutStatus(true);
        }

        protected override void OnStartDragItem(ItemModel obj)
        {
            base.OnStartDragItem(obj);
            _dropContextSwitcher.SwitchToPlayerToTrader();
        }
    }
}