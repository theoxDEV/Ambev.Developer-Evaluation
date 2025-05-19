using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using Xunit;
using Ambev.DeveloperEvaluation.WebApi;

namespace Ambev.DeveloperEvaluation.Tests.Functional.Sales
{
    public class CreateSaleEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CreateSaleEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "Given valid sale data When calling POST /api/sales Then returns 200 OK with sale ID")]
        public async Task Post_ValidSale_ReturnsOk()
        {
            // Arrange
            var request = new
            {
                customerId = Guid.NewGuid(),
                customerName = "Test Customer",
                branchId = Guid.NewGuid(),
                branchName = "Test Branch",
                items = new[]
                {
                    new { description = "Keyboard", quantity = 5, price = 150 }
                }
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/sales", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.Content.ReadFromJsonAsync<CreateSaleResponse>();
            body.Should().NotBeNull();
            body!.SaleId.Should().NotBe(Guid.Empty);
        }

        private class CreateSaleResponse
        {
            public Guid SaleId { get; set; }
        }
    }
}