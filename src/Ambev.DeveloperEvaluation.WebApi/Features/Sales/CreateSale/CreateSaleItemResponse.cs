namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for individual sale items in a sale
    /// </summary>
    public class CreateSaleItemResponse
    {
        /// <summary>
        /// The external identifier of the product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The denormalized product name
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// The quantity of the product sold
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the product
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The discount applied to the item (e.g., 0.1 for 10%)
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The total value of the item after discount
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Indicates whether this item was cancelled
        /// </summary>
        public bool IsCancelled { get; set; }
    }

}
