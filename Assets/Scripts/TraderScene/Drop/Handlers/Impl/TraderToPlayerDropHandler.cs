using TraderScene.Models.Inventory;
using TraderScene.Services.Inventory.Impl;
using TraderScene.Services.Wallet;
using Zenject;

namespace TraderScene.Drop.Handlers.Impl
{
    /// <summary>
    /// Handles the logic for transferring an item from the trader's inventory to the player's inventory.
    /// The item's price is reduced based on the trading ratio.
    /// </summary>
    public class TraderToPlayerDropHandler : IDropHandler
    {
        [Inject] private PlayerInventoryService _playerInventoryService;
        [Inject] private TraderInventoryService _traderInventoryService;
        [Inject] private WalletService _walletService;
        
        /// <summary>
        /// Ratio to adjust the price of the item after the trade
        /// </summary>
        private const float RationTrade = .5f;

        public void HandleDrop(ItemModel item)
        {
            if (!_walletService.TrySpendGold(item.Price))
            {
                return;
            }
            
            var price = item.Price;
            var newPrice = (int)(price * RationTrade);
            item.UpdatePrice(newPrice);
            
            _playerInventoryService.AddItem(item);
            _traderInventoryService.RemoveItem(item);
        }
    }
}