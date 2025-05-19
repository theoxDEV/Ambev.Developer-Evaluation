using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Ambev.DeveloperEvaluation.Tests.Functional.Sales
{
    public class GetSaleByIdEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public GetSaleByIdEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "GET /api/sales/{id} - Should return 200 for a valid sale")]
        public async Task GetSaleById_ReturnsSuccess()
        {
            // Arrange: create a sale first
            var createRequest = new
            {
                customerId = Guid.NewGuid(),
                customerName = "Client",
                branchId = Guid.NewGuid(),
                branchName = "Branch",
                items = new[] { new { description = "Mouse", quantity = 4, price = 100 } }
            };

            var createResponse = await _client.PostAsJsonAsync("/api/sales", createRequest); 
            
            createResponse.IsSuccessStatusCode.Should().BeTrue("sale creation must succeed for the test");

            var created = await createResponse.Content.ReadFromJsonAsync<CreateSaleResponse>();

            var body = await createResponse.Content.ReadAsStringAsync();
            Console.WriteLine(body); // ajuda a entender o erro real

            // Act
            var response = await _client.GetAsync($"/api/sales/{created!.Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "GET /api/sales/{id} - Should return 404 for an unknown sale")]
        public async Task GetSaleById_ReturnsNotFound()
        {
            // Arrange
            var nonExistentId = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";

            // Act
            var response = await _client.GetAsync($"/api/sales/{nonExistentId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        public class CreateSaleResponse
        {
            public Guid Id { get; set; }
        }
    }
}