using System.Net;
using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Ambev.DeveloperEvaluation.Tests.Functional.Sales
{
    public class GetAllSalesEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public GetAllSalesEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "GET /api/sales - Should return 200 and a list of sales")]
        public async Task GetAllSales_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/sales");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}