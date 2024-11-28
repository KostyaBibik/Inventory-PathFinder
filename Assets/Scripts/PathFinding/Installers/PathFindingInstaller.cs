using PathFinding.Core.Interfaces;
using PathFinding.Core.Services;
using PathFinding.Core.Visualization;
using PathFinding.Test;
using UnityEngine;
using Zenject;

namespace PathFinding.Installers
{
    public class PathFindingInstaller : MonoInstaller
    {
        [SerializeField] private PathFinderTests _test;
        
        public override void InstallBindings()
        {
            BindPathFinderComponents();
            BindDrawComponents();
            BindTests();
        }

        private void BindPathFinderComponents()
        {
            Container.Bind<IPathFinder>().To<PathFinderService>().AsSingle();
        }

        private void BindDrawComponents()
        {
            Container.Bind<IDrawer>().To<PathDrawer>().AsSingle().NonLazy();
        }

        private void BindTests()
        {
            Container.BindInterfacesTo<PathFinderTests>().FromInstance(_test).AsSingle().NonLazy();
        }
    }
}