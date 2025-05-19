using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Handles the cancellation of a sale.
    /// </summary>
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResponse>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CancelSaleHandler> _logger;

        public CancelSaleHandler(ISaleRepository repository, IMapper mapper, ILogger<CancelSaleHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<CancelSaleResponse> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.Id);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found.");

            if (sale.IsCancelled)
                throw new InvalidOperationException("Sale is already cancelled.");

            sale.Cancel();

            await _repository.SaveChangesAsync();

            _logger.LogInformation("Event: SaleCancelled | SaleId: {SaleId} | Time: {Time}", sale.Id, DateTime.UtcNow);

            return _mapper.Map<CancelSaleResponse>(sale);
        }
    }
}
