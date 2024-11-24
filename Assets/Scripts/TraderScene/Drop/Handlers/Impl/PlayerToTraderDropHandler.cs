using TraderScene.Models.Inventory;
using TraderScene.Services.Inventory.Impl;
using TraderScene.Services.Wallet;
using Zenject;

namespace TraderScene.Drop.Handlers.Impl
{
    /// <summary>
    /// Handles the logic for transferring an item from the player's inventory to the trader's inventory.
    /// The item's price is increased based on the trading ratio.
    /// </summary>
    public class PlayerToTraderDropHandler : IDropHandler
    {
        [Inject] private PlayerInventoryService _playerInventoryService;
        [Inject] private TraderInventoryService _traderInventoryService;
        [Inject] private WalletService _walletService;

        /// <summary>
        /// Ratio to adjust the price of the item after the trade
        /// </summary>
        private const int RationTrade = 2;
        
        public void HandleDrop(ItemModel item)
        {
            var price = item.Price;
            _walletService.AddGold(price);

            var newPrice = price * RationTrade;
            item.UpdatePrice(newPrice);
            
            _traderInventoryService.AddItem(item);
            _playerInventoryService.RemoveItem(item);
        }
    }
}