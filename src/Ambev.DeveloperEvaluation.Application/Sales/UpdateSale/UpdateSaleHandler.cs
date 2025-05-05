using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Handler that updates the fields of a sale.
    /// </summary>
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResponse>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSaleHandler> _logger;

        public UpdateSaleHandler(ISaleRepository repository, IMapper mapper, ILogger<UpdateSaleHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<UpdateSaleResponse> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.Id);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found.");

            sale.CustomerName = request.CustomerName;
            sale.BranchId = request.BranchId;
            sale.BranchName = request.BranchName;

            await _repository.SaveChangesAsync();

            _logger.LogInformation("Event: SaleModified | SaleId: {SaleId} | Time: {Time}", sale.Id, DateTime.UtcNow);

            return _mapper.Map<UpdateSaleResponse>(sale);
        }
    }

}
