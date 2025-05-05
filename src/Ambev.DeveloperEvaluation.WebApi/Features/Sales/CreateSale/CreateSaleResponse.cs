namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique sale number for tracking and reporting
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date and time when the sale was created
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// The external identifier of the customer associated with the sale
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The denormalized customer name
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// The external identifier of the branch where the sale occurred
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// The denormalized branch name
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// The total monetary value of the sale after discounts
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indicates whether the sale was marked as cancelled
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// The list of items included in the sale
        /// </summary>
        public List<CreateSaleItemResponse> Items { get; set; } = new();
    }

}
