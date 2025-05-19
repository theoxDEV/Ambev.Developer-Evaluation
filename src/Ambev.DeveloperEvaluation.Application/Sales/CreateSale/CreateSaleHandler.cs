using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Handler for <see cref="CreateSaleCommand"/>.
    /// </summary>
    /// <remarks>
    /// Handles the process of creating a new sale and saving it to the database.
    /// </remarks>
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _repository;

        private readonly ILogger<CreateSaleHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleHandler"/> class.
        /// </summary>
        /// <param name="repository">The sale repository.</param>
        public CreateSaleHandler(ISaleRepository repository, ILogger<CreateSaleHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var saleNumber = $"SALE-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
            var saleDate = request.SaleDate ?? DateTime.UtcNow;

            var sale = new Sale(
                saleNumber,
                saleDate,
                request.CustomerId,
                request.CustomerName,
                request.BranchId,
                request.BranchName
            );

            foreach (var item in request.Items)
            {
                var mockProductId = Guid.NewGuid();
                sale.AddItem(mockProductId, item.Description, item.Quantity, item.Price);
            }

            await _repository.AddAsync(sale);
            await _repository.SaveChangesAsync();

            _logger.LogInformation("Event: SaleCreated | SaleId: {SaleId} | Time: {Time}", sale.Id, DateTime.UtcNow);

            return new CreateSaleResult { SaleId = sale.Id };
        }

    }

}
