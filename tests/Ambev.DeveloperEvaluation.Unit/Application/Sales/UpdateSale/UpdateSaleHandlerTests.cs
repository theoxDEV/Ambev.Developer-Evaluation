using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.UpdateSale
{
    public class UpdateSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<UpdateSaleHandler>> _loggerMock;
        private readonly UpdateSaleHandler _handler;

        public UpdateSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<UpdateSaleHandler>>();
            _handler = new UpdateSaleHandler(_saleRepositoryMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Fact(DisplayName = "Given valid sale data When updating Then returns updated response")]
        public async Task Handle_ValidUpdate_ReturnsUpdatedResponse()
        {
            // Arrange
            var command = new UpdateSaleCommand
            {
                Id = Guid.NewGuid(),
                CustomerName = "Updated Customer",
                BranchId = Guid.NewGuid(),
                BranchName = "Updated Branch"
            };

            var sale = new Sale(
                saleNumber: "SALE-123",
                saleDate: DateTime.UtcNow,
                customerId: Guid.NewGuid(),
                customerName: "Original",
                branchId: Guid.NewGuid(),
                branchName: "Original Branch"
            );

            var expectedResponse = new UpdateSaleResponse
            {
                Id = command.Id,
                CustomerName = command.CustomerName,
                BranchName = command.BranchName
            };

            _saleRepositoryMock.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync(sale);
            _mapperMock.Setup(m => m.Map<UpdateSaleResponse>(sale)).Returns(expectedResponse);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CustomerName.Should().Be(command.CustomerName);
            result.BranchName.Should().Be(command.BranchName);

            _saleRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact(DisplayName = "Given invalid ID When updating sale Then throws NotFoundException")]
        public async Task Handle_InvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateSaleCommand
            {
                Id = Guid.NewGuid(),
                CustomerName = "Nome",
                BranchId = Guid.NewGuid(),
                BranchName = "Branch"
            };

            _saleRepositoryMock.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync((Sale)null!);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
            _saleRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
        }
    }
}
