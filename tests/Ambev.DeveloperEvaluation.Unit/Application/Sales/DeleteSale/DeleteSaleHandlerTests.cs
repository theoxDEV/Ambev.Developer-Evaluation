using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.DeleteSale
{
    public class DeleteSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _repository = new();
        private readonly Mock<ILogger<DeleteSaleHandler>> _logger = new();
        private readonly DeleteSaleHandler _handler;

        public DeleteSaleHandlerTests()
        {
            _handler = new DeleteSaleHandler(_repository.Object, _logger.Object);
        }

        [Fact(DisplayName = "Given valid sale ID When deleting Then calls delete and save")]
        public async Task Handle_ValidId_DeletesSale()
        {
            // Arrange
            var sale = new Sale("SALE-999", DateTime.UtcNow, Guid.NewGuid(), "Cliente", Guid.NewGuid(), "Filial");

            _repository.Setup(r => r.GetByIdAsync(sale.Id)).ReturnsAsync(sale);

            // Act
            await _handler.Handle(new DeleteSaleCommand { Id = sale.Id }, default);

            // Assert
            _repository.Verify(r => r.Delete(sale), Times.Once);
            _repository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact(DisplayName = "Given invalid ID When deleting Then throws NotFoundException")]
        public async Task Handle_InvalidId_ThrowsNotFound()
        {
            // Arrange
            _repository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Sale)null!);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _handler.Handle(new DeleteSaleCommand { Id = Guid.NewGuid() }, default));
        }
    }
}
