using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Seeds
{

    public static class SaleSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var saleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var sale2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

            modelBuilder.Entity<Sale>().HasData(
                new
                {
                    Id = saleId,
                    SaleNumber = "SALE-0001",
                    SaleDate = DateTime.UtcNow,
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Client C",
                    BranchId = Guid.NewGuid(),
                    BranchName = "South Store",
                    TotalAmount = 4800m,
                    IsCancelled = false
                },
                new
                {
                    Id = sale2Id,
                    SaleNumber = "SALE-0002",
                    SaleDate = DateTime.UtcNow,
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Client B",
                    BranchId = Guid.NewGuid(),
                    BranchName = "Rio Store",
                    TotalAmount = 300m,
                    IsCancelled = false
                }
            );

            modelBuilder.Entity<SaleItem>().HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    ProductName = "LED Monitor",
                    Quantity = 15,
                    UnitPrice = 400m,
                    Discount = 0.2m,
                    SaleId = saleId,
                    IsCancelled = false
                },
                new
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    ProductName = "Gamer Mouse",
                    Quantity = 3,
                    UnitPrice = 100m,
                    Discount = 0m,
                    SaleId = sale2Id,
                    IsCancelled = false
                }
            );
        }
    }
}
