namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Response model returned after updating a sale.
    /// </summary>
    public class UpdateSaleResponse
    {
        /// <summary>
        /// Gets or sets the ID of the updated sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the updated customer name.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated branch name.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated sale date.
        /// </summary>
        public DateTime SaleDate { get; set; }
    }

}
