using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TraderScene.Views.Inventory.Items
{
    public class ItemInventoryView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private TextMeshProUGUI _name;

        protected bool IsBusy;
        
        public void Refresh()
        {
            _price.text = string.Empty;
            _name.text = string.Empty;
            _icon.enabled = false;
            IsBusy = false;
        }

        public virtual void UpdateView(
            string name,
            string price,
            Sprite icon = null
        )
        {
            IsBusy = true;
            
            _name.text = name;
            _price.text = price;
            SetIcon(icon);
        }

        private void SetIcon(Sprite icon)
        {
            if (icon == null)
            {
                return;
            }
            
            _icon.enabled = true;
            _icon.sprite = icon;
        }
    }
}