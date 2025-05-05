using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Command for creating a new sale.
    /// </summary>
    /// <remarks>
    /// This command is used to initiate the creation of a new sale,
    /// including customer name and associated items. It implements
    /// <see cref="IRequest{TResponse}"/> to return a <see cref="CreateSaleResult"/>.
    /// 
    /// The data is validated using <see cref="CreateSaleCommandValidator"/>.
    /// </remarks>
    /// <summary>
    /// Command to create a new sale with customer, branch, and item details.
    /// </summary>
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer name for the sale.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch identifier where the sale is being made.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the branch name where the sale is being made.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sale date. If not provided, the current UTC date will be used.
        /// </summary>
        public DateTime? SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the list of sale items.
        /// </summary>
        public List<CreateSaleItemDto> Items { get; set; } = new();

        /// <summary>
        /// Validates the command using <see cref="CreateSaleCommandValidator"/>.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> indicating whether the command is valid.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }

    /// <summary>
    /// DTO representing a sale item to be included in a sale.
    /// </summary>
    public class CreateSaleItemDto
    {
        /// <summary>
        /// Gets or sets the item description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item.
        /// </summary>
        public int Quantity { get; set; }
    }
}
