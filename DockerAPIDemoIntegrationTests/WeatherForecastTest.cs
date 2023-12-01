using DockerAPIDemo;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Xunit;

namespace DockerAPIDemoIntegrationTests
{
    public class WeatherForecastTest : IntegrationTest
    {
        public WeatherForecastTest(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Fact]
        public async void Test1()
        {
            var client = _factory.CreateClient();
            var createRequest = GenerateRequest(client, HttpMethod.Get, null, "/WeatherForecast", "");
            var response = await client.SendAsync(createRequest);

            var getJson = await response.Content.ReadAsStringAsync();
            IEnumerable<WeatherForecast> forecasts = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(getJson);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(forecasts.Count(), 5);
        }
    }
}