using System.Collections.Generic;
using System.Linq;
using TraderScene.Models.Inventory;
using TraderScene.Views.Common;
using UnityEngine;

namespace TraderScene.Views.Inventory
{
    public class InventoryView : MonoBehaviour, IUIView
    {
        [SerializeField] private ItemInventoryView _itemTemplate;
        [SerializeField] private Transform _itemsParent;
        
        private ItemInventoryView[] _items;
        
        public void UpdateContent(IReadOnlyList<ItemModel> itemModels)
        {
            UpdateItemsCount(itemModels.Count);
            UpdateItemsContent(itemModels);
        }
        
        private void UpdateItemsCount(int count)
        {
            if (_items == null || !_items.Any())
            {
                _items = new[] { _itemTemplate };
            }
            
            if (count > _items.Length)
            {
                var template = _items.First();
                var createCount = count - _items.Length;
                _items = _items.Concat(Enumerable.Range(0, createCount)
                        .Select(_ => Instantiate(template, _itemsParent)))
                    .ToArray();
            }
            else
            {
                for (var i = 0; i < _items.Length; i++)
                {
                    _items[i].gameObject.SetActive(i < count);
                }
            }
        }

        private void UpdateItemsContent(IReadOnlyList<ItemModel> itemModels)
        {
            for (var i = 0; i < itemModels.Count; i++)
            {
                var item = _items[i];
                var model = itemModels[i];

                if(model.Icon != null)
                    item.Icon.sprite = model.Icon;
                item.Count.text = model.Count.ToString();
                item.Name.text = model.Name;
                item.Price.text = model.Price.ToString();
            }
        }
    }
}