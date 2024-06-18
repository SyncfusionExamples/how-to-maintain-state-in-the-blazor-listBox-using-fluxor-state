using BlazorFluxor.Data;
using BlazorFluxor.Store;
using Fluxor;


namespace Dialogs.Store.ForecastUseCase
{
#pragma warning disable IDE0060
    public class Effects
    {
        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Cold", "Mild", "Hot"
        };
        private static readonly int[] Temperatures = new[]
        {
            0,-2,-4,-6,//index range 0-3 relates to summaries[index/4]==summaries[0]
            2,6,8,10,//index range 4-7 relates to summaries[index/4]==summaries[1]
            12,14,16,18,
            23,24,26,28

        };
        private CancellationTokenSource? _cts;

        [EffectMethod]
        public async Task HandleEventFetchDataInitialized(EventMsgPageInitialized action, IDispatcher dispatcher)
        {
            try
            {
                await foreach (var forecast in ForecastStreamAsync(DateOnly.FromDateTime(DateTime.Now), 7))
                {

                    dispatcher.Dispatch(new SetForecast(forecast, false, false));
                }

            }
            catch (TimeoutException ex)
            {
                dispatcher.Dispatch(new SetDbError(ex.Message, true, false));
            }

        }


        public async IAsyncEnumerable<WeatherForecast> ForecastStreamAsync(DateOnly startDate, int count)
        {
            int timeout = _cts == null ? 1500 : 2000;//timeout on first call only
            using var cts = _cts = new(timeout);

            try
            {
                await Task.Delay(1750, _cts.Token);
            }
            //make sure the correct OperationCanceledExceptionn is caught here
            catch (OperationCanceledException) when (_cts.Token.IsCancellationRequested)
            {
                throw new TimeoutException("The operation timed out.Please try again");

            }

            for (int i = 0; i < count; i++)
            {
                int temperatureIndex = Random.Shared.Next(0, Temperatures.Length);
                int summaryIndex = temperatureIndex / 4;//relate summary to a temp range
                await Task.Delay(125);//simulate slow data stream
                yield return new WeatherForecast
                {
                    Date = startDate.AddDays(i),
                    TemperatureC = Temperatures[temperatureIndex],
                    Summary = Summaries[summaryIndex]
                };
            }

        }

    }
}
