using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem
{
    /// <summary>
    /// Handles the cancellation of a specific sale item.
    /// </summary>
    public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, Unit>
    {
        private readonly ISaleRepository _repository;
        private readonly ILogger<CancelSaleItemHandler> _logger;

        public CancelSaleItemHandler(ISaleRepository repository, ILogger<CancelSaleItemHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Unit> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.SaleId);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found.");

            var item = sale.Items.FirstOrDefault(i => i.Id == request.ItemId);
            if (item == null)
                throw new KeyNotFoundException("Item not found.");

            item.IsCancelled = true;
            sale.RecalculateTotal();

            await _repository.SaveChangesAsync();

            _logger.LogInformation("Event: ItemCancelled | SaleId: {SaleId} | ItemId: {ItemId}", sale.Id, item.Id);

            return Unit.Value;
        }
    }
}
