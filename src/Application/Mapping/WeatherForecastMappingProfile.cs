using AutoMapper;
using SignalR_Demo.Application.ViewModels;
using SignalR_Demo.Domain;

namespace SignalR_Demo.Application.Mapping
{
    public class WeatherForecastMappingProfile : Profile
    {
        public WeatherForecastMappingProfile()
        {
            this.CreateMap<WeatherForecast, WeatherForecastViewModel>();
        }
    }
}
