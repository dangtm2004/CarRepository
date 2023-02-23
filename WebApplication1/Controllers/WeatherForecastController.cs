using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public int GetbyId(int id)
        {
            return id;
        }

        [HttpPost]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status201Created)]
        public WeatherForecast Create(WeatherForecast forecast)
        {
            return forecast;

        }

        [HttpPut("{id}")]
        public WeatherForecast Update(int id, WeatherForecast weatherForecast)
        {
            return weatherForecast;
        }

  //      [HttpDelete("{id}")]
   //     public String Delete(int id)                                                                                                   n  
  //      {
  //          return "Successfully deleted";
  //      }
    }
}