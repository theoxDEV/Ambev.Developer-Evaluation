using System.Net;
using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Ambev.DeveloperEvaluation.Tests.Functional.Sales
{
    public class DeleteSaleEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public DeleteSaleEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "DELETE /api/sales/{id} - Should delete sale and return 204")]
        public async Task DeleteSale_ReturnsNoContent()
        {
            // Arrange
            var existingId = "11111111-1111-1111-1111-111111111111";

            // Act
            var response = await _client.DeleteAsync($"/api/sales/{existingId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact(DisplayName = "DELETE /api/sales/{id} - Should return 404 if sale does not exist")]
        public async Task DeleteSale_NonExistent_ReturnsNotFound()
        {
            // Arrange
            var nonExistentId = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";

            // Act
            var response = await _client.DeleteAsync($"/api/sales/{nonExistentId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}