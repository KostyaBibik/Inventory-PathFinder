using TraderScene.Models.Wallet;
using UniRx;

namespace TraderScene.Services.Wallet
{
    public class WalletService
    {
        private readonly WalletModel _walletModel = new WalletModel(BaseGold);

        public IReadOnlyReactiveProperty<int> Gold => _walletModel.Gold;
        
        private const int BaseGold = 100;
        
        public bool TrySpendGold(int amount)
            => _walletModel.TrySpendGold(amount);

        public void AddGold(int amount)
            => _walletModel.AddGold(amount);
    }
}