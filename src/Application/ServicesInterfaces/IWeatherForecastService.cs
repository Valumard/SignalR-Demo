using SignalR_Demo.Application.ViewModels;
using System.Collections.Generic;

namespace SignalR_Demo.Application.ServiceInterfaces
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecastViewModel> GetWeatherForecasts();        
    }
}
