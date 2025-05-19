using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Seeds
{
    public static class AdditionalSaleSeed
    {
        public static void SeedBusinessRuleExamples(this ModelBuilder modelBuilder)
        {
            var saleRule1 = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var saleRule2 = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var saleRule3 = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var saleRule4 = Guid.Parse("66666666-6666-6666-6666-666666666666");

            modelBuilder.Entity<Sale>().HasData(
                new
                {
                    Id = saleRule1,
                    SaleNumber = "SALE-RULE1",
                    SaleDate = DateTime.UtcNow,
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Rule: < 4 items (no discount)",
                    BranchId = Guid.NewGuid(),
                    BranchName = "Branch A",
                    TotalAmount = 300m,
                    IsCancelled = false
                },
                new
                {
                    Id = saleRule2,
                    SaleNumber = "SALE-RULE2",
                    SaleDate = DateTime.UtcNow,
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Rule: 4–9 items (10%)",
                    BranchId = Guid.NewGuid(),
                    BranchName = "Branch B",
                    TotalAmount = 900m,
                    IsCancelled = false
                },
                new
                {
                    Id = saleRule3,
                    SaleNumber = "SALE-RULE3",
                    SaleDate = DateTime.UtcNow,
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Rule: 10–20 items (20%)",
                    BranchId = Guid.NewGuid(),
                    BranchName = "Branch C",
                    TotalAmount = 1600m,
                    IsCancelled = false
                },
                new
                {
                    Id = saleRule4,
                    SaleNumber = "SALE-RULE4",
                    SaleDate = DateTime.UtcNow,
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Rule: > 20 items (invalid case)",
                    BranchId = Guid.NewGuid(),
                    BranchName = "Branch D",
                    TotalAmount = 0m,
                    IsCancelled = false
                }
            );

            modelBuilder.Entity<SaleItem>().HasData(
                // Rule 1: Less than 4 items, no discount
                new
                {
                    Id = Guid.Parse("aaa10001-0000-0000-0000-000000000001"),
                    ProductId = Guid.NewGuid(),
                    ProductName = "Mouse",
                    Quantity = 2,
                    UnitPrice = 150m,
                    Discount = 0m,
                    SaleId = saleRule1,
                    IsCancelled = false
                },

                // Rule 2: Between 4 and 9 items → 10% discount
                new
                {
                    Id = Guid.Parse("aaa10002-0000-0000-0000-000000000002"),
                    ProductId = Guid.NewGuid(),
                    ProductName = "Keyboard",
                    Quantity = 6,
                    UnitPrice = 150m,
                    Discount = 0.1m,
                    SaleId = saleRule2,
                    IsCancelled = false
                },

                // Rule 3: Between 10 and 20 items → 20% discount
                new
                {
                    Id = Guid.Parse("aaa10003-0000-0000-0000-000000000003"),
                    ProductId = Guid.NewGuid(),
                    ProductName = "Headset",
                    Quantity = 10,
                    UnitPrice = 200m,
                    Discount = 0.2m,
                    SaleId = saleRule3,
                    IsCancelled = false
                },

                // Rule 4: Invalid case (> 20 items)
                new
                {
                    Id = Guid.Parse("aaa10004-0000-0000-0000-000000000004"),
                    ProductId = Guid.NewGuid(),
                    ProductName = "Webcam",
                    Quantity = 25,
                    UnitPrice = 300m,
                    Discount = 0m,
                    SaleId = saleRule4,
                    IsCancelled = false
                }
            );
        }
    }
}
