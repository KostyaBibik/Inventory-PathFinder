using TraderScene.Models.Inventory;
using TraderScene.Services.Inventory;
using TraderScene.Services.Inventory.Impl;
using UniRx;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class TestTrader : IInitializable
    {
        [Inject] private PlayerInventoryService _playerInventoryService;
        
        public void Initialize()
        {
            Observable
                .EveryUpdate()
                .Where(_ => UnityEngine.Input.GetKeyDown(KeyCode.W))
                .Subscribe(_ => AddItem());
            
            Observable
                .EveryUpdate()
                .Where(_ => UnityEngine.Input.GetKeyDown(KeyCode.R))
                .Subscribe(_ => DestroyItem());
        }

        private void AddItem()
        {
            Debug.Log("AddItem");
            var item = new ItemModel("TEst", 100, null);
            _playerInventoryService.AddItem(item);
        }
        
        private void DestroyItem()
        {
            Debug.Log("DestroyItem");
            var item = _playerInventoryService.Items[0];
            _playerInventoryService.RemoveItem(item);
        }
    }
}