using System;
using TraderScene.Views;
using Zenject;

namespace TraderScene.Presenters
{
    public abstract class UIPresenter<TView> : IInitializable, IDisposable
        where TView : IUIView
    {
        private TView _window;

        public TView Window => _window;
        
        public UIPresenter(TView window)
        {
            _window = window;
        }

        public virtual void Initialize()
        {
        }
        
        public virtual void Dispose()
        {
        }
    }
}