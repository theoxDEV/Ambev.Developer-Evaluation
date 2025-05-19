using System.Net;
using System.Net.Http.Json;
using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Ambev.DeveloperEvaluation.Tests.Functional.Sales
{
    public class UpdateSaleEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UpdateSaleEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "PUT /api/sales/{id} - Should update sale and return 200")]
        public async Task UpdateSale_ReturnsSuccess()
        {
            // Arrange
            var existingId = "11111111-1111-1111-1111-111111111111";
            var updatePayload = new
            {
                id = existingId,
                customerName = "Updated Customer",
                branchId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                branchName = "Updated Branch"
            };

            // Act
            var response = await _client.PutAsJsonAsync($"/api/sales/{existingId}", updatePayload);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "PUT /api/sales/{id} - Should return 404 if sale doesn't exist")]
        public async Task UpdateSale_NonExistent_ReturnsNotFound()
        {
            // Arrange
            var nonExistentId = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
            var updatePayload = new
            {
                id = nonExistentId,
                customerName = "Any Customer",
                branchId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                branchName = "Any Branch"
            };

            // Act
            var response = await _client.PutAsJsonAsync($"/api/sales/{nonExistentId}", updatePayload);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}