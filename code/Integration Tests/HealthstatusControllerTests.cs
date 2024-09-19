using IT1IOTest1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Model;
using Xunit;

namespace IntegrationTests
{
    public class HealthstatusControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HealthstatusControllerTests()
        {
            // Arrange
            var projectDir = Helper.GetProjectPath("", typeof(HealthstatusControllerTests).Assembly);
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task FullCheckSuccess()
        {
            // Act
            var response = await _client.GetAsync("/healthstatus");
            response.EnsureSuccessStatusCode();
            
            var result = await response.Content.ReadFromJsonAsync<Response<Healthstatus>>();

            // Assert
            Assert.Null(result.Error);
        }
    }
}