using DockerAPIDemo;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Xunit;

namespace DockerAPIDemoUnitTests
{
    public class WeatherForecastTest
    {
        [Fact]
        public void WeatherForecastPropertyCheck()
        {
            WeatherForecast w = new WeatherForecast();
            w.MyAppSetting1 = "1";
            Assert.Equal(w.MyAppSetting1, "1");
        }
    }
}