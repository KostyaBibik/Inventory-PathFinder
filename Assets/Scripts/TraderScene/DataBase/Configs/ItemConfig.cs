using UnityEngine;

namespace TraderScene.DataBase.Configs
{
    [CreateAssetMenu(menuName = "Config/" + nameof(ItemConfig),
        fileName = nameof(ItemConfig))]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _price;

        public string Name => _name;
        public Sprite Icon => _icon;
        public int Price => _price;
    }
}