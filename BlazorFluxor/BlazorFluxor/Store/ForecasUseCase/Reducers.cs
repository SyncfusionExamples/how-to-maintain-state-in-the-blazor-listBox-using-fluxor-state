
using Fluxor;

namespace BlazorFluxor.Store.ForecastUseCase
{ 
#pragma warning disable IDE0060
    public class Reducers
{

    [ReducerMethod]
    public static ForecastState ReduceSetForecast(ForecastState state, SetForecast action)
    {
        return state with
        {
            Forecasts = state.Forecasts.Add(action.Forecast),
            IsError = action.IsError,
            IsLoading = action.IsLoading
        };
    }
    [ReducerMethod]
    public static ForecastState ReduceRequestSetErrorAction(ForecastState state, SetDbError action)
    {
        return state with
        {
            IsError = action.IsError,
            IsLoading = action.IsLoading,
            Message = action.ErrorMessage
        };
    }

    [ReducerMethod]
    public static ForecastState ReduceSetStateToNew(ForecastState state, SetStateToNew action)
    {
        return new ForecastState();
    }
}
}
