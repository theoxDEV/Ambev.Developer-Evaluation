namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    /// <summary>
    /// API response model for listing basic information about sales.
    /// </summary>
    /// <summary>
    /// API response model for listing complete sale information.
    /// </summary>
    public class GetAllSalesResponse
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Gets the list of items associated with the sale.
        /// </summary>
        public List<GetSaleItemResponse> Items { get; set; } = new();
    }
}
