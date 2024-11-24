using System;
using System.Collections.Generic;
using System.Linq;
using TraderScene.Models.Inventory;
using TraderScene.Services.Draggable;
using TraderScene.Views.Inventory.Items.Impl;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TraderScene.Views.Inventory.Windows
{
    public class InventoryView : MonoBehaviour, IUIView
    {
        [SerializeField] private CellItemInventoryView _itemTemplate;
        [SerializeField] private LayoutGroup _itemsLayout;

        [Inject] private DragItemService _dragItemService;

        private const int InitialCountCells = 9;
        
        private CellItemInventoryView[] _items;
        public Action<ItemModel> DragStarted;
        public Action<ItemModel> DragEnded;
        
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public LayoutGroup ItemsLayout => _itemsLayout;
        
        private void Awake()
        {
            UpdateItemsCount(InitialCountCells);
        }

        public void UpdateContent(IReadOnlyList<ItemModel> itemModels)
        {
            UpdateItemsCount(itemModels.Count);
            UpdateItemsContent(itemModels);
        }
        
        /// <summary>
        /// Updates the number of items in the inventory,
        /// creating new ones or refreshing existing ones if count is less than the current amount.
        /// </summary>
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
                        .Select(_ => Instantiate(template, _itemsLayout.transform)))
                    .ToArray();
            }
            else
            {
                for (var i = 0; i < _items.Length; i++)
                {
                    if(i > count)
                    {
                        _items[i].Refresh();
                    }
                }
            }
        }

        private void UpdateItemsContent(IReadOnlyList<ItemModel> itemModels)
        {
            _compositeDisposable.Clear();

            for (var i = 0; i < itemModels.Count; i++)
            {
                var item = _items[i];
                var model = itemModels[i];

                var itemName = model.Name;
                var price = model.Price.ToString();
                var icon = model.Icon;
                
                item.UpdateView(itemName, price, icon);
                
                item.OnDragStarted = () => OnStartDragItem(model);
                item.OnDragEnd = () => OnEndDragItem(model);
            }

            for (var i = itemModels.Count; i < _items.Length; i++)
            {
                var item = _items[i];
                item.Refresh();
            }
        }

        private void OnStartDragItem(ItemModel model)
        {
            DragStarted?.Invoke(model);
            _dragItemService.SetDraggableItem(model);
        }

        private void OnEndDragItem(ItemModel model)
        {
            DragEnded?.Invoke(model);
        }

        private void OnDestroy()
        {
            _compositeDisposable?.Dispose();
        }
    }
}