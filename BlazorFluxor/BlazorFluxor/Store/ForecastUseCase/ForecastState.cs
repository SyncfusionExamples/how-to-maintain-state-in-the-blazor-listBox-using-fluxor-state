
using BlazorFluxor.Data;
using Fluxor;
using System.Collections.Immutable;
namespace BlazorFluxor.Store.ForecastUseCase
{
  [FeatureState]
public record ForecastState(
        ImmutableList<WeatherForecast> Forecasts,
        string? Message,
        bool IsError,
        bool IsLoading)
{
    public ForecastState() : this(ImmutableList.Create<WeatherForecast>(), null, false, true)
    {

    }
}

}
