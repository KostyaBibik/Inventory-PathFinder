using System.Linq;
using TraderScene.Drop;
using TraderScene.Models.Inventory;
using TraderScene.Services.Inventory.Impl;
using TraderScene.Views.Inventory.Windows.Impl;
using Zenject;

namespace TraderScene.Presenters.Inventory.Impl
{
    public class TraderInventoryPresenter : InventoryPresenter<TraderInventoryWindow, TraderInventoryService>
    {
        [Inject] private DropContextSwitcher _dropContextSwitcher;
        
        public TraderInventoryPresenter(
            TraderInventoryWindow window,
            TraderInventoryService inventoryService
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
            _dropContextSwitcher.SwitchToTraderToPlayer();
        }
    }
}