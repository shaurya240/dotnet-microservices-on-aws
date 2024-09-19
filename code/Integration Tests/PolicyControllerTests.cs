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
    public class PolicyControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public PolicyControllerTests()
        {
            // Arrange
            var projectDir = Helper.GetProjectPath("", typeof(PolicyControllerTests).Assembly);

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
        public async Task ListPoliciesSuccess()
        {
            // Act
            var response = await _client.GetAsync("/policies");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Response<IEnumerable<Policy>>>();

            // Assert
            //Assert.True(result.Count > 1);
            //Assert.Equal("HARIS PETROU", result.[0].Holder);
            Assert.Null(result.Error);
        }

        [Fact]
        public async Task CreatePolicySuccess()
        {
            // Act
            var response = await _client.PostAsJsonAsync("/policies", new CreatePolicy {Holder = "Jack Black"});
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Response<Model.Policy>>();

            // Assert
            Assert.Null(result.Error);
        }
    }
}