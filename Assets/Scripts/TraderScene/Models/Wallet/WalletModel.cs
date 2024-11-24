using UniRx;

namespace TraderScene.Models.Wallet
{
    public class WalletModel
    {
        public ReactiveProperty<int> Gold { get; private set; }

        public WalletModel(int initialGold)
        {
            Gold = new ReactiveProperty<int>(initialGold);
        }

        public bool TrySpendGold(int amount)
        {
            if (Gold.Value >= amount)
            {
                Gold.Value -= amount;
                return true;
            }
            return false;
        }

        public void AddGold(int amount)
        {
            Gold.Value += amount;
        }
    }
}