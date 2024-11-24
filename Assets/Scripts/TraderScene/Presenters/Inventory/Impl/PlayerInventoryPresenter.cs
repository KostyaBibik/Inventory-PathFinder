using System.Linq;
using TraderScene.Services.Inventory.Impl;
using TraderScene.Views.Inventory.Impl;

namespace TraderScene.Presenters.Inventory.Impl
{
    public class PlayerInventoryPresenter : InventoryPresenter<PlayerInventoryView, PlayerInventoryService>
    {
        public PlayerInventoryPresenter(PlayerInventoryView view, PlayerInventoryService inventoryService) 
            : base(view, inventoryService)
        {
        }

        protected override void UpdateView()
        {
            View.UpdateContent(InventoryService.Items.ToList());
        }
    }
}