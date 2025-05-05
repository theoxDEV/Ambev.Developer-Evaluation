using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents an individual item within a Sale, including product reference, quantity, pricing, and discounts.
    /// Follows DDD principles with external identity and denormalized product data.
    /// </summary>
    public partial class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the external product identifier.
        /// This references the product from an external product domain.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the denormalized product name.
        /// Used for reporting and display purposes without needing to query the external domain.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product sold.
        /// Business rule: cannot be less than 1 and cannot exceed 20 units per item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product at the time of sale.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to this item as a decimal percentage (e.g., 0.1 = 10%).
        /// Value must be between 0 and 1.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets the total amount for this item after applying the discount.
        /// Calculated as (Quantity * UnitPrice) * (1 - Discount).
        /// </summary>
        public decimal Total => Quantity * UnitPrice * (1 - Discount);

        /// <summary>
        /// Indicates whether this item was cancelled in the context of the sale.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Gets or sets the foreign key reference to the Sale entity this item belongs to.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Navigation property to the parent Sale entity.
        /// </summary>
        public Sale Sale { get; set; } = null!;
    }

}
