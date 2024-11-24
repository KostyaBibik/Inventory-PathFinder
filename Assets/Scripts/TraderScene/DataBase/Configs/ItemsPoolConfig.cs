using System.Collections.Generic;
using UnityEngine;

namespace TraderScene.DataBase.Configs
{
    [CreateAssetMenu(menuName = "Config/" + nameof(ItemsPoolConfig),
        fileName = nameof(ItemsPoolConfig))]
    public class ItemsPoolConfig : ScriptableObject
    {
        [SerializeField] private List<ItemConfig> _configs;

        public IReadOnlyList<ItemConfig> Configs => _configs;
    }
}