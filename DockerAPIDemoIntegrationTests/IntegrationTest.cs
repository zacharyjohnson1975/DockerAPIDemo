using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DockerAPIDemoIntegrationTests
{
    public abstract class IntegrationTest : IClassFixture<ApiWebApplicationFactory>, IDisposable
    {
        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;
        //protected readonly ISqlAdapter _sqlAdapter;

        public IntegrationTest(ApiWebApplicationFactory fixture)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "IntegrationTests");
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "DockerAPIDemo");

            _factory = fixture;
            _client = _factory.CreateClient();
            _client.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //_sqlAdapter = new SqlAdapterFixture().SqlAdapter;
        }

        public void Dispose()
        {
            _client.Dispose();
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", string.Empty);
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", string.Empty);
        }

        public HttpRequestMessage GenerateRequest(HttpClient client, HttpMethod method, HttpContent content, string uri, string authToken)
        {
            var relativeUri = uri;
            client.DefaultRequestHeaders.Clear();
            Uri requestUri = new Uri(client.BaseAddress, relativeUri);
            var request = new HttpRequestMessage()
            {
                RequestUri = requestUri,
                Method = method
            };

            if (content != null)
            {
                request.Content = content;
            }

            if (!string.IsNullOrEmpty(authToken) && !authToken.Contains("auth"))
            {
                var authHeader = new AuthenticationHeaderValue("Authorization", authToken);
                client.DefaultRequestHeaders.Authorization = authHeader;
            }

            return request;
        }
    }
}
