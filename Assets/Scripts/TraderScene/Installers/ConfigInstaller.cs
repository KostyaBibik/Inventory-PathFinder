using TraderScene.DataBase.Configs;
using UnityEngine;
using Zenject;

namespace TraderScene.Installers
{
    [CreateAssetMenu(fileName = nameof(ConfigInstaller),
        menuName = "Installers/" + nameof(ConfigInstaller))]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] private ItemsPoolConfig _itemsPoolConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_itemsPoolConfig);
        }
    }
}