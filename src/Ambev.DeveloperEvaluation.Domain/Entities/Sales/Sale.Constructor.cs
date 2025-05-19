using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public partial class Sale : BaseEntity
    {
        public Sale(string saleNumber, DateTime saleDate, Guid customerId, string customerName, Guid branchId, string branchName)
        {
            Id = Guid.NewGuid(); // Herdado de BaseEntity
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            TotalAmount = 0m;
            IsCancelled = false;
            Items = new List<SaleItem>();
        }

        /// <summary>
        /// Adds an item to the sale and updates the total amount.
        /// </summary>
        public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity < 1 || quantity > 20)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be between 1 and 20.");

            decimal discount = 0;

            if (quantity >= 10 && quantity <= 20)
                discount = 0.20m;
            else if (quantity >= 4)
                discount = 0.10m;

            var item = new SaleItem(productId, productName, quantity, unitPrice, discount, this.Id);
            Items.Add(item);
            RecalculateTotal();
        }

        /// <summary>
        /// Recalculates the total amount of the sale based on its items.
        /// </summary>
        public void RecalculateTotal()
        {
            TotalAmount = Items.Where(i => !i.IsCancelled).Sum(i => i.Total);
        }

        /// <summary>
        /// Cancels the sale.
        /// </summary>
        public void Cancel()
        {
            IsCancelled = true;
        }

        // EF Core needs this for migrations
        protected Sale() { }
    }
}
