using Fluxor;

namespace BlazorFluxor.Store.ValueUseCase
{
    public class Effects
    {
        private readonly IState<ValueState> _valueState;
        
        public Effects(IState<ValueState> valueState)
        {
            _valueState = valueState;
        }

        [EffectMethod]
        public Task HandleEventCounterClicked(EventValueClicked action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetValueAction(action.Items));
            return Task.CompletedTask;
        }
    }
}
