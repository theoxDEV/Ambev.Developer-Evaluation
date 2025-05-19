namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Response returned after cancelling a sale.
    /// </summary>
    public class CancelSaleResponse
    {
        /// <summary>
        /// Gets or sets the ID of the cancelled sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates that the sale has been cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }
    }
}
