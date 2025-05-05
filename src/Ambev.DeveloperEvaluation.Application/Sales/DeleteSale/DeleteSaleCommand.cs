using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Command to delete a sale by ID.
    /// </summary>
    /// <remarks>
    /// This command performs a hard delete of the sale and its items from the database.
    /// </remarks>
    public class DeleteSaleCommand : IRequest<Unit>
    {
        /// <summary>
        /// Gets or sets the ID of the sale to be deleted.
        /// </summary>
        public Guid Id { get; set; }
    }
}
