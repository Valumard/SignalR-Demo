using AutoMapper;
using SignalR_Demo.Application.ServiceInterfaces;
using SignalR_Demo.Application.ViewModels;
using SignalR_Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    internal class WeatherForecastService : IWeatherForecastService
    {
        public WeatherForecastService(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IMapper Mapper { get; }

        public IEnumerable<WeatherForecastViewModel> GetWeatherForecasts()
        {
            var rng = new Random();
            var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            var forecastVMs = this.Mapper.Map<IEnumerable<WeatherForecastViewModel>>(forecast);

            return forecastVMs;
        }
    }
}
