using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetAllSales
{
    public class GetAllSalesHandlerTests
    {
        private readonly Mock<ISaleRepository> _repository = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly GetAllSalesHandler _handler;

        public GetAllSalesHandlerTests()
        {
            _handler = new GetAllSalesHandler(_repository.Object, _mapper.Object);
        }

        [Fact(DisplayName = "When getting all sales Then returns list of responses")]
        public async Task Handle_GetAllSales_ReturnsSalesList()
        {
            // Arrange
            var sales = new List<Sale>
            {
                new("SALE-001", DateTime.UtcNow, Guid.NewGuid(), "Cliente", Guid.NewGuid(), "Filial")
            };

            var responses = new List<GetAllSalesResponse>
            {
                new() { Id = Guid.NewGuid(), SaleNumber = "SALE-001" }
            };

            _repository.Setup(r => r.GetAllAsync()).ReturnsAsync(sales);
            _mapper.Setup(m => m.Map<List<GetAllSalesResponse>>(sales)).Returns(responses);

            // Act
            var result = await _handler.Handle(new GetAllSalesQuery(), default);

            // Assert
            result.Should().HaveCount(1);
            result.First().SaleNumber.Should().Be("SALE-001");
        }
    }
}
