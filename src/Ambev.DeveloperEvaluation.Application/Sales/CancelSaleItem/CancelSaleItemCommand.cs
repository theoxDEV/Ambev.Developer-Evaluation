using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem
{
    /// <summary>
    /// Command for cancelling a specific item within a sale.
    /// </summary>
    public class CancelSaleItemCommand : IRequest<Unit>
    {
        public Guid SaleId { get; set; }
        public Guid ItemId { get; set; }
    }
}
