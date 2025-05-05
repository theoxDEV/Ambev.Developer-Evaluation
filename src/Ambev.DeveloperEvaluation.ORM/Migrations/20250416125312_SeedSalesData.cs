using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class SeedSalesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "BranchId", "BranchName", "CustomerId", "CustomerName", "IsCancelled", "SaleDate", "SaleNumber", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("2af37d97-9fd7-40fe-b9fb-94af36926c5b"), "South Store", new Guid("7c443f17-cb02-491a-b773-fad061eb4281"), "Client C", false, new DateTime(2025, 4, 16, 12, 53, 12, 413, DateTimeKind.Utc).AddTicks(1927), "SALE-0001", 4800m },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("375b86be-c378-4ee2-87e9-f037be7d5db5"), "Rio Store", new Guid("a4720f2a-17f5-446d-8785-360d9baa5e7b"), "Client B", false, new DateTime(2025, 4, 16, 12, 53, 12, 413, DateTimeKind.Utc).AddTicks(1958), "SALE-0002", 300m }
                });

            migrationBuilder.InsertData(
                table: "SaleItems",
                columns: new[] { "Id", "Discount", "IsCancelled", "ProductId", "ProductName", "Quantity", "SaleId", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("4968d1f2-798a-4ee7-95f2-f9037e7ba498"), 0m, false, new Guid("7e271c75-2bf6-45e3-8612-4c2725263757"), "Gamer Mouse", 3, new Guid("22222222-2222-2222-2222-222222222222"), 100m },
                    { new Guid("75bce800-b422-4249-874e-0a8d4f83bc12"), 0.2m, false, new Guid("305a0d13-203e-445b-a96c-f4d0c4eeaf00"), "LED Monitor", 15, new Guid("11111111-1111-1111-1111-111111111111"), 400m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("4968d1f2-798a-4ee7-95f2-f9037e7ba498"));

            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("75bce800-b422-4249-874e-0a8d4f83bc12"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
