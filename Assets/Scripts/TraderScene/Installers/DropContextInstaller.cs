using TraderScene.Drop;
using TraderScene.Drop.Context.Impl;
using TraderScene.Drop.Handlers.Impl;
using TraderScene.Services.Draggable;
using Zenject;

namespace TraderScene.Installers
{
    public class DropContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
            BindHandlers();
            BindContextSwitcher();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<DragItemService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DropContext>().AsSingle();
        }

        private void BindHandlers()
        {
            Container.Bind<PlayerToTraderDropHandler>().AsTransient();
            Container.Bind<TraderToPlayerDropHandler>().AsTransient();
        }

        private void BindContextSwitcher()
        {
            Container.Bind<DropContextSwitcher>().AsSingle();
        }
    }
}