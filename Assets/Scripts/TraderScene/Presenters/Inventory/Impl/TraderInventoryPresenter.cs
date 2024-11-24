using System.Linq;
using TraderScene.Services.Inventory.Impl;
using TraderScene.Views.Inventory.Impl;

namespace TraderScene.Presenters.Inventory.Impl
{
    public class TraderInventoryPresenter : InventoryPresenter<TraderInventoryView, TraderInventoryService>
    {
        public TraderInventoryPresenter(TraderInventoryView view, TraderInventoryService inventoryService)
            : base(view, inventoryService)
        {
        }

        protected override void UpdateView()
        {
            View.UpdateContent(InventoryService.Items.ToList());
        }
    }
}