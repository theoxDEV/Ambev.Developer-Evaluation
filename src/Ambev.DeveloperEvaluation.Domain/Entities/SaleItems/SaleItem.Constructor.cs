namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public partial class SaleItem
    {
        public SaleItem(Guid productId, string productName, int quantity, decimal unitPrice, decimal discount, Guid saleId)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            SaleId = saleId;
            IsCancelled = false;
        }

        /// <summary>
        /// Cancels this item.
        /// </summary>
        public void Cancel()
        {
            IsCancelled = true;
        }
    }
}
