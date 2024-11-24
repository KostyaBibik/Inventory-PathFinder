using TraderScene.Extensions;
using TraderScene.Presenters.Wallet;
using TraderScene.Services.Wallet;
using TraderScene.Views.Wallet;
using Zenject;

namespace TraderScene.Installers
{
    public class WalletInstaller : MonoInstaller<WalletInstaller>
    {
        public override void InstallBindings()
        {
            InstallServices();
            InstallUI();
        }

        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<WalletService>().AsSingle();
        }

        private void InstallUI()
        {
            Container.BindPresenterWithView<WalletPresenter, WalletWindow>();
        }
    }
}