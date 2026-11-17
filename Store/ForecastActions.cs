using BlazorFluxor.Data;

namespace BlazorFluxor.Store
{
    public record SetForecast(WeatherForecast Forecast, bool IsError, bool IsLoading);
    public record SetDbError(string ErrorMessage, bool IsError, bool IsLoading);
    public record EventMsgPageInitialized();  
    public record SetStateToNew();
}

