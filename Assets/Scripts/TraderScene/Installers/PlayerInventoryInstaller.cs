using DefaultNamespace;
using TraderScene.Extensions;
using TraderScene.Presenters.Inventory.Impl;
using TraderScene.Services.Inventory.Impl;
using TraderScene.Views.Inventory.Impl;
using Zenject;

namespace TraderScene.Installers
{
    public class PlayerInventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallServices();
            InstallUI();
            
            //DEBUG
            Container.BindInterfacesAndSelfTo<TestTrader>().AsSingle().NonLazy();
        }

        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<PlayerInventoryService>().AsSingle();
        }

        private void InstallUI()
        {
            Container.BindPresenterWithView<PlayerInventoryPresenter, PlayerInventoryView>();
        }
    }
}