namespace Ambev.DeveloperEvaluation.Application.Sales
{
    /// <summary>
    /// Response model representing an item inside a sale.
    /// </summary>
    public class GetSaleItemResponse
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        /// <summary>
        /// Total amount for this item after discount.
        /// </summary>
        public decimal Total { get; set; }
    }
}
