using TraderScene.Drop.Context;
using TraderScene.Drop.Handlers.Impl;
using Zenject;

namespace TraderScene.Drop
{
    public class DropContextSwitcher
    {
        private readonly IDropContext _dropContext;
        private readonly PlayerToTraderDropHandler _playerToTraderHandler;
        private readonly TraderToPlayerDropHandler _traderToPlayerHandler;

        [Inject]
        public DropContextSwitcher(
            IDropContext dropContext,
            PlayerToTraderDropHandler playerToTraderHandler,
            TraderToPlayerDropHandler traderToPlayerHandler
        )
        {
            _dropContext = dropContext;
            _playerToTraderHandler = playerToTraderHandler;
            _traderToPlayerHandler = traderToPlayerHandler;
        }

        public void SwitchToPlayerToTrader()
        {
            _dropContext.SetHandler(_playerToTraderHandler);
        }

        public void SwitchToTraderToPlayer()
        {
            _dropContext.SetHandler(_traderToPlayerHandler);
        }
    }
}