using TraderScene.Models.Inventory;
using TraderScene.Services.Inventory;
using TraderScene.Views.Inventory.Windows;
using UniRx;

namespace TraderScene.Presenters.Inventory
{
    public abstract class InventoryPresenter <TView, TService> : UIPresenter<TView>
        where TView : InventoryView
        where TService : InventoryService
    {
        protected readonly TService InventoryService;
        
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        
        protected InventoryPresenter(TView window, TService inventoryService) : base(window)
        {
            InventoryService = inventoryService;
        }

        public override void Initialize()
        {
            BindView();
            SetupDragHandlers();
        }

        private void BindView()
        {
            InventoryService.Items
                .ObserveCountChanged()
                .Subscribe(_ => UpdateView())
                .AddTo(_disposable);

            UpdateView();
        }
        
        private void SetupDragHandlers()
        {
            Window.DragStarted = OnStartDragItem;
            Window.DragEnded = OnEndDragItem;
        }
        
        protected virtual void OnStartDragItem(ItemModel obj)
        {
            SwitchItemsLayoutStatus(false);
        }

        protected virtual void OnEndDragItem(ItemModel obj)
        {
            SwitchItemsLayoutStatus(true);
        }

        /// <summary>
        /// When `ItemsLayout` is enabled, users can interact with inventory items.
        /// When disabled, interactions are blocked, typically during item dragging, 
        /// to prevent conflicts with item placement or other interactions.
        /// </summary>
        protected void SwitchItemsLayoutStatus(bool flag)
        {
            Window.ItemsLayout.enabled = flag;
        }
        
        protected abstract void UpdateView();

        public override void Dispose()
        {
            _disposable.Dispose();
        }
    }
}