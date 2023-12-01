using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using DockerAPIDemo;
using Microsoft.AspNetCore.TestHost;

namespace DockerAPIDemoIntegrationTests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                IConfigurationRoot integrationConfig;

                integrationConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.local.json", true, true)
                .Build();

                config.AddConfiguration(integrationConfig);
            });

            builder.ConfigureTestServices(services =>
            {
            });
        }
    }
}
