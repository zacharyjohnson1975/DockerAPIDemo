using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
//test comment
namespace DockerAPIDemo.Controllers
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
        private readonly AppSettingsOptions _appSettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<AppSettingsOptions> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                MyAppSetting1 = _appSettings.MyAppSetting1,
                MyAppSetting2 = _appSettings.MyAppSetting2,
                MyAppSetting3 = _appSettings.MyAppSetting3,
                TheEnvSetting = Environment.GetEnvironmentVariable("MYENVVAR"),
        })
            .ToArray();
        }
    }
}