using TraderScene.Extensions;
using TraderScene.Presenters.Inventory.Impl;
using TraderScene.Services.Inventory.Impl;
using TraderScene.Views.Inventory.Windows.Impl;
using Zenject;

namespace TraderScene.Installers
{
    public class TraderInventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallServices();
            InstallUI();
        }
        
        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<TraderInventoryService>().AsSingle();
        }

        private void InstallUI()
        {
            Container.BindPresenterWithView<TraderInventoryPresenter, TraderInventoryWindow>();
        }
    }
}