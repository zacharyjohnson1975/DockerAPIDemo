using System;

namespace DockerAPIDemo
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        public string? MyAppSetting1 { get; set; }
        public string? MyAppSetting2 { get; set; }
        public string? MyAppSetting3 { get; set; }
        public string? TheEnvSetting { get; set; }
    }
}