using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sales transaction in the system, containing customer, branch, and item-level details.
    /// Follows DDD and External Identity patterns.
    /// </summary>
    public partial class Sale : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique sale number for tracking and reporting purposes.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time the sale was completed.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the external customer identifier from another domain.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the denormalized customer name for display and reporting.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the external branch identifier where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the denormalized branch name for display and reporting.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total monetary value of the sale, including all discounts.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indicates whether the sale has been cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Gets or sets the collection of sale items related to this sale.
        /// Each item includes quantity, unit price, discounts, and item total.
        /// </summary>
        public List<SaleItem> Items { get; private set; } = new();
    }
}
