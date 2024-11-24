using TraderScene.Services.Inventory;
using TraderScene.Views;
using UniRx;

namespace TraderScene.Presenters.Inventory
{
    public abstract class InventoryPresenter <TView, TService> : UIPresenter<TView>
        where TView : IUIView
        where TService : InventoryService
    {
        protected readonly TService InventoryService;
        
        private CompositeDisposable _disposable = new CompositeDisposable();
        
        protected InventoryPresenter(TView view, TService inventoryService) : base(view)
        {
            InventoryService = inventoryService;
        }

        public override void Initialize()
        {
            BindView();
        }

        private void BindView()
        {
            InventoryService.Items
                .ObserveCountChanged()
                .Subscribe(_ => UpdateView())
                .AddTo(_disposable);

            UpdateView();
        }

        protected abstract void UpdateView();

        public override void Dispose()
        {
            _disposable.Dispose();
        }
    }
}