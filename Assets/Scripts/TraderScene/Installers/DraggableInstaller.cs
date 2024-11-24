using TraderScene.Services.Draggable;
using Zenject;

namespace TraderScene.Installers
{
    public class DraggableInstaller : MonoInstaller<DraggableInstaller>
    {
        public override void InstallBindings()
        {
            InstallServices();
        }

        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<DragItemService>().AsSingle().NonLazy();
        }
    }
}