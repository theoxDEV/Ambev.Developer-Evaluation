using System.Net;
using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Ambev.DeveloperEvaluation.Tests.Functional.Sales
{
    public class CancelSaleEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CancelSaleEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "PATCH /api/sales/{id}/cancel - Should cancel sale and return 200")]
        public async Task CancelSale_ReturnsSuccess()
        {
            // Arrange
            var existingId = "11111111-1111-1111-1111-111111111111";

            // Act
            var response = await _client.PatchAsync($"/api/sales/{existingId}/cancel", null);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "PATCH /api/sales/{id}/cancel - Should return 404 if sale not found")]
        public async Task CancelSale_NonExistent_ReturnsNotFound()
        {
            // Arrange
            var nonExistentId = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";

            // Act
            var response = await _client.PatchAsync($"/api/sales/{nonExistentId}/cancel", null);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}