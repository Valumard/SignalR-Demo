using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalR_Demo.Application.ServiceInterfaces;
using SignalR_Demo.HubConfig;
using SignalR_Demo.TimerFeatures;

namespace SignalR_Demo.Controllers
{
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService weatherForecastService;
        private readonly IHubContext<WeatherForecastHub> hubContext;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            IWeatherForecastService weatherForecastService,
            IHubContext<WeatherForecastHub> hubContext)
        {
            _logger = logger;
            this.weatherForecastService = weatherForecastService;
            this.hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var forecast = this.weatherForecastService.GetWeatherForecasts();
            var timerManager = new TimerManager(() => this.hubContext.Clients.All.SendAsync("transferWeatherForecast", forecast));

            return Ok(new { Message = "Everythings fine." });
        }
    }
}
