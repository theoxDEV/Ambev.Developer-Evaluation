using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validates the <see cref="CreateSaleCommand"/> ensuring all required fields are present and valid.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - CustomerName: Required, must be between 3 and 100 characters.
    /// - Items: Must contain at least one item.
    /// - Each item:
    ///   - Description: Required, 3–100 characters.
    ///   - Quantity: Greater than 0.
    ///   - Price: Must be >= 0.
    /// </remarks>
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleCommandValidator"/> class
        /// with defined validation rules for sale creation.
        /// </summary>
        public CreateSaleCommandValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .Length(3, 100).WithMessage("Customer name must be between 3 and 100 characters.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one sale item is required.");

            RuleForEach(x => x.Items).SetValidator(new CreateSaleItemDtoValidator());
        }
    }

    /// <summary>
    /// Validates individual sale items in the <see cref="CreateSaleCommand"/>.
    /// </summary>
    public class CreateSaleItemDtoValidator : AbstractValidator<CreateSaleItemDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleItemDtoValidator"/> class
        /// with defined validation rules for each sale item.
        /// </summary>
        public CreateSaleItemDtoValidator()
        {
            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("Item description is required.")
                .Length(3, 100).WithMessage("Item description must be between 3 and 100 characters.");

            RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(i => i.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative.");
        }
    }
}
