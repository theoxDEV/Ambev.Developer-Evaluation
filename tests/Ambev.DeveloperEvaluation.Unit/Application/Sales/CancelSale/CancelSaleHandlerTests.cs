using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CancelSale
{
    public class CancelSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _repository = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly Mock<ILogger<CancelSaleHandler>> _logger = new();
        private readonly CancelSaleHandler _handler;

        public CancelSaleHandlerTests()
        {
            _handler = new CancelSaleHandler(_repository.Object, _mapper.Object, _logger.Object);
        }

        [Fact(DisplayName = "Given valid sale ID When cancelling Then sets IsCancelled")]
        public async Task Handle_ValidId_CancelsSale()
        {
            // Arrange
            var sale = new Sale("SALE-123", DateTime.UtcNow, Guid.NewGuid(), "Cliente", Guid.NewGuid(), "Filial");
            var command = new CancelSaleCommand { Id = sale.Id };
            var response = new CancelSaleResponse { Id = sale.Id, IsCancelled = true };

            _repository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync(sale);
            _mapper.Setup(m => m.Map<CancelSaleResponse>(sale)).Returns(response);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsCancelled.Should().BeTrue();
            _repository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact(DisplayName = "Given already cancelled sale When cancelling Then throws InvalidOperationException")]
        public async Task Handle_AlreadyCancelled_Throws()
        {
            // Arrange
            var sale = new Sale("SALE-001", DateTime.UtcNow, Guid.NewGuid(), "Cliente", Guid.NewGuid(), "Filial");
            sale.Cancel();

            _repository.Setup(r => r.GetByIdAsync(sale.Id)).ReturnsAsync(sale);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _handler.Handle(new CancelSaleCommand { Id = sale.Id }, default));
        }
    }
}
