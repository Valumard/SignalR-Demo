using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalR_Demo.Application.ServiceInterfaces;
using SignalR_Demo.Application.ViewModels;
using System.Collections.Generic;

namespace SignalR_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            this.weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecastViewModel>> Get()
        {
            var forecast = this.weatherForecastService.GetWeatherForecasts();

            return Ok(forecast);
        }
    }
}
