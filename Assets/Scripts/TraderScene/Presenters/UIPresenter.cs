using System;
using TraderScene.Views;
using Zenject;

namespace TraderScene.Presenters
{
    public abstract class UIPresenter<TView> : IInitializable, IDisposable
        where TView : IUIView
    {
        private TView _view;

        public TView View => _view;
        
        public UIPresenter(TView view)
        {
            _view = view;
        }

        public virtual void Initialize()
        {
        }
        
        public virtual void Dispose()
        {
        }
    }
}