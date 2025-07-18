using Microsoft.AspNetCore.Mvc;

namespace Web_API_Versioning.API.V1.Controllers
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class WeatherForecastControllerV1 : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly"
        };

        private readonly ILogger<WeatherForecastControllerV1> _logger;

        public WeatherForecastControllerV1(ILogger<WeatherForecastControllerV1> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
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
