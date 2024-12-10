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
            BindDrawComponents();
            BindPathFinderComponents();
            BindTests();
        }

        private void BindPathFinderComponents()
        {
            Container.Bind<IPathFinder>().To<PathFinderService>().AsSingle();
        }

        private void BindDrawComponents()
        {
            Container.BindInterfacesAndSelfTo<PathDrawer>().AsSingle().NonLazy();
        }

        private void BindTests()
        {
            Container.BindInterfacesTo<PathFinderTests>().FromInstance(_test).AsSingle().NonLazy();
        }
    }
}