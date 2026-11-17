


using Fluxor;

namespace BlazorFluxor.Store.CounterUseCase
{
    public class Reducers
    {
        [ReducerMethod]
        public static CounterState ReduceSetCounterTotal(CounterState state,SetCounterTotal action)
        {
            return state with { TotalCount = action.TotalCount };
        }
    }
}
