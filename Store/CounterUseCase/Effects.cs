
using Fluxor;

namespace BlazorFluxor.Store.CounterUseCase
{
    public class Effects
    {
        private readonly IState<CounterState> _counterState;


        public Effects(IState<CounterState> counterState)
        {
            _counterState = counterState;
        }

        [EffectMethod]
      public Task  HandleEventCounterClicked(EventCounterClicked action,IDispatcher dispatcher)
        {
            int totalCount = _counterState.Value.TotalCount + action.Increment;
            dispatcher.Dispatch(new SetCounterTotal(totalCount));
            return Task.CompletedTask;
        }
    }
}
