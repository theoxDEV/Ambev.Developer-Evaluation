using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using Castle.Core.Logging;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CreateSale
{
    public class CreateSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly Mock<ILogger<CreateSaleHandler>> _logger = new();
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _handler = new CreateSaleHandler(_saleRepositoryMock.Object, _logger.Object);
        }

        /// <summary>
        /// Tests that a valid sale creation request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid sale data When creating sale Then returns sale id")]
        public async Task Handle_ValidRequest_ReturnsSaleId()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.GenerateValidCommand();

            _saleRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Sale>()))
                .Returns(Task.CompletedTask);

            _saleRepositoryMock
                .Setup(r => r.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.NotEqual(Guid.Empty, result.SaleId);

            _saleRepositoryMock.Verify(r => r.AddAsync(It.Is<Sale>(s =>
                s.CustomerName == command.CustomerName && s.Items.Count == 2
            )), Times.Once);

            _saleRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact(DisplayName = "Given repository throws on AddAsync When handling sale Then exception is propagated")]
        public async Task Handle_AddAsyncThrows_ThrowsException()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.GenerateValidCommand();

            _saleRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Sale>()))
                .ThrowsAsync(new Exception("Add failed"));

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, default));
            ex.Message.Should().Be("Add failed");

            _saleRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Sale>()), Times.Once);
            _saleRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
        }

        [Fact(DisplayName = "Given repository throws on SaveChangesAsync When handling sale Then exception is propagated")]
        public async Task Handle_SaveChangesThrows_ThrowsException()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.GenerateValidCommand();

            _saleRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Sale>()))
                .Returns(Task.CompletedTask);

            _saleRepositoryMock
                .Setup(r => r.SaveChangesAsync())
                .ThrowsAsync(new Exception("Save failed"));

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, default));
            ex.Message.Should().Be("Save failed");

            _saleRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Sale>()), Times.Once);
            _saleRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact(DisplayName = "Given invalid sale item When handling sale Then throws ArgumentOutOfRangeException")]
        public async Task Handle_InvalidSaleItem_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var command = CreateSaleHandlerTestData.GenerateValidCommand();
            command.Items[0].Quantity = 0;

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _handler.Handle(command, default));
            ex.ParamName.Should().Be("quantity");

            _saleRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Sale>()), Times.Never);
            _saleRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
        }
    }
}
