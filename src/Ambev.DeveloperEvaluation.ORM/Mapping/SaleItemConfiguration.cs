using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.ProductId)
                .IsRequired();

            builder.Property(item => item.ProductName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(item => item.Quantity)
                .IsRequired();

            builder.Property(item => item.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(item => item.Discount)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(item => item.IsCancelled)
                .IsRequired();

            builder.Property(item => item.SaleId)
                .IsRequired();

            builder.HasOne(item => item.Sale)
                .WithMany(sale => sale.Items)
                .HasForeignKey(item => item.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
