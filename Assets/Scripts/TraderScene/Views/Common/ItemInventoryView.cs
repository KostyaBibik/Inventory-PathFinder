using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TraderScene.Views.Common
{
    public class ItemInventoryView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private TextMeshProUGUI _name;

        public Image Icon => _icon;
        public TextMeshProUGUI Price => _price;
        public TextMeshProUGUI Count => _count;
        public TextMeshProUGUI Name => _name;
    }
}