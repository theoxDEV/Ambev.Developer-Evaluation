using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(sale => sale.Id);

            builder.Property(sale => sale.SaleNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(sale => sale.SaleDate)
                .IsRequired();

            builder.Property(sale => sale.CustomerId)
                .IsRequired();

            builder.Property(sale => sale.CustomerName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(sale => sale.BranchId)
                .IsRequired();

            builder.Property(sale => sale.BranchName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(sale => sale.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(sale => sale.IsCancelled)
                .IsRequired();

            builder.HasMany(sale => sale.Items)
                .WithOne(item => item.Sale)
                .HasForeignKey(item => item.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
