using TraderScene.Services.Wallet;
using TraderScene.Views.Wallet;
using UniRx;
using Zenject;

namespace TraderScene.Presenters.Wallet
{
    public class WalletPresenter : UIPresenter<WalletWindow>
    {
        [Inject] private WalletService _walletService;

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();
        
        public WalletPresenter(WalletWindow window) : base(window)
        {
        }

        public override void Initialize()
        {
            _walletService.Gold
                .ObserveEveryValueChanged(amount => amount.Value) 
                .Subscribe(OnChangeGold)
                .AddTo(_compositeDisposable);
        }
        
        private void OnChangeGold(int newGoldAmount)
        {
            Window.UpdateGoldAmount(newGoldAmount);  
        }

        public override void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}