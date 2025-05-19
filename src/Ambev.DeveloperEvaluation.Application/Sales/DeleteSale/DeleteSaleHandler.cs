using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Handles the deletion of a sale from the system.
    /// </summary>
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, Unit>
    {
        private readonly ISaleRepository _repository;
        private readonly ILogger<DeleteSaleHandler> _logger;

        public DeleteSaleHandler(ISaleRepository repository, ILogger<DeleteSaleHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.Id);

            if (sale == null)
                throw new KeyNotFoundException("Sale not found.");

            _repository.Delete(sale);
            await _repository.SaveChangesAsync();

            _logger.LogInformation("Event: SaleDeleted | SaleId: {SaleId}", sale.Id);

            return Unit.Value;
        }
    }
}
