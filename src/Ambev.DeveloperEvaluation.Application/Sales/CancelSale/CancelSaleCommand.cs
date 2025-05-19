using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Command for cancelling an existing sale.
    /// </summary>
    /// <remarks>
    /// This command marks the sale as cancelled without deleting it.
    /// </remarks>
    public class CancelSaleCommand : IRequest<CancelSaleResponse>
    {
        /// <summary>
        /// Gets or sets the ID of the sale to be cancelled.
        /// </summary>
        public Guid Id { get; set; }
    }
}
