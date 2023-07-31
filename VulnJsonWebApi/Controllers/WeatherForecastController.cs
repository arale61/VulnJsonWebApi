using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace VulnJsonWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var items = InMemoryForecastRepo.GetAllForecasts();

            return Ok(items);
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public IActionResult WeatherForecast([FromBody]WeatherForecast newForeCast) 
        {
            InMemoryForecastRepo.AddItem(newForeCast);

            return Ok();
        }
    }
}