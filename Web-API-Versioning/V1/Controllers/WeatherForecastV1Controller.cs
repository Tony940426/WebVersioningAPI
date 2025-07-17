using Microsoft.AspNetCore.Mvc;

namespace Web_API_Versioning.API.V1.Controllers
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class WeatherForecastV1Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly"
        };

        private readonly ILogger<WeatherForecastV1Controller> _logger;

        public WeatherForecastV1Controller(ILogger<WeatherForecastV1Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastV2")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
