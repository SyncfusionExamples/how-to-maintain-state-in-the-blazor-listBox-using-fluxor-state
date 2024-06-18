using Fluxor;

namespace BlazorFluxor.Store.CounterUseCase
{
    [FeatureState]
    public record CounterState(int TotalCount)
    {
        public CounterState() : this(0)//default constructor
        {

        }
    }
}
