using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetSale
{
    public class GetSaleByIdHandlerTests
    {
        private readonly Mock<ISaleRepository> _repository = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly GetSaleByIdHandler _handler;

        public GetSaleByIdHandlerTests()
        {
            _handler = new GetSaleByIdHandler(_repository.Object, _mapper.Object);
        }

        [Fact(DisplayName = "Given valid ID When getting sale Then returns sale response")]
        public async Task Handle_ValidId_ReturnsSale()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var sale = new Sale("SALE-001", DateTime.UtcNow, Guid.NewGuid(), "Cliente", Guid.NewGuid(), "Filial");
            var response = new GetSaleByIdResponse { Id = saleId };

            _repository.Setup(r => r.GetByIdAsync(saleId)).ReturnsAsync(sale);
            _mapper.Setup(m => m.Map<GetSaleByIdResponse>(sale)).Returns(response);

            // Act
            var result = await _handler.Handle(new GetSaleByIdQuery { Id = saleId }, default);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(saleId);
        }

        [Fact(DisplayName = "Given invalid ID When getting sale Then throws NotFoundException")]
        public async Task Handle_InvalidId_ThrowsNotFound()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            _repository.Setup(r => r.GetByIdAsync(saleId)).ReturnsAsync((Sale)null!);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _handler.Handle(new GetSaleByIdQuery { Id = saleId }, default));
        }
    }
}
