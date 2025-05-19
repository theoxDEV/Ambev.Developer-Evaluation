using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Command for updating an existing sale.
    /// </summary>
    /// <remarks>
    /// This command is used to update fields such as branch, customer and sale date.
    /// Sale items are not modified here.
    /// </remarks>
    public class UpdateSaleCommand : IRequest<UpdateSaleResponse>
    {
        /// <summary>
        /// Gets or sets the ID of the sale to be updated.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the new customer name.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the new branch ID.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the new branch name.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>

    }
}
