using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class SeedBusinessRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("4968d1f2-798a-4ee7-95f2-f9037e7ba498"));

            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("75bce800-b422-4249-874e-0a8d4f83bc12"));

            migrationBuilder.InsertData(
                table: "SaleItems",
                columns: new[] { "Id", "Discount", "IsCancelled", "ProductId", "ProductName", "Quantity", "SaleId", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("40bb13df-55ae-465b-a7bb-117eb03407b5"), 0m, false, new Guid("1d372efe-2bb8-43b0-95ae-e69b542e80fa"), "Gamer Mouse", 3, new Guid("22222222-2222-2222-2222-222222222222"), 100m },
                    { new Guid("845d8ece-9c6b-4e1f-930c-fd6a136ca4b6"), 0.2m, false, new Guid("d8a43b21-d346-4ce2-ad8e-60a4ec7b7547"), "LED Monitor", 15, new Guid("11111111-1111-1111-1111-111111111111"), 400m }
                });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "BranchId", "CustomerId", "SaleDate" },
                values: new object[] { new Guid("e5cafcf3-bb8f-4c5e-b64c-61b65890e5fd"), new Guid("5814ae18-07f5-454e-8e91-1c58b446b500"), new DateTime(2025, 4, 16, 12, 59, 24, 689, DateTimeKind.Utc).AddTicks(6608) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "BranchId", "CustomerId", "SaleDate" },
                values: new object[] { new Guid("3f6ffc28-6709-4faa-9a5b-6e824ba1abe5"), new Guid("ba88d782-b0e9-47c7-b5af-d7222c9e2bdf"), new DateTime(2025, 4, 16, 12, 59, 24, 689, DateTimeKind.Utc).AddTicks(6641) });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "BranchId", "BranchName", "CustomerId", "CustomerName", "IsCancelled", "SaleDate", "SaleNumber", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("b8daf8e7-ed7f-43d9-82b2-11eefeb228f5"), "Branch A", new Guid("ff08029b-53b7-47db-9e91-7d1a48f5314a"), "Rule: < 4 items (no discount)", false, new DateTime(2025, 4, 16, 12, 59, 24, 689, DateTimeKind.Utc).AddTicks(6730), "SALE-RULE1", 300m },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("609e52c3-5431-48b1-97d5-2e99f77ba3f3"), "Branch B", new Guid("4633ac96-9b00-48d0-9487-c07d1386b79c"), "Rule: 4–9 items (10%)", false, new DateTime(2025, 4, 16, 12, 59, 24, 689, DateTimeKind.Utc).AddTicks(6733), "SALE-RULE2", 900m },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("c6338af7-d712-46ba-95e6-78bb5cb00fd5"), "Branch C", new Guid("ff69aac0-b29e-463f-b4c6-d82e6d3b068d"), "Rule: 10–20 items (20%)", false, new DateTime(2025, 4, 16, 12, 59, 24, 689, DateTimeKind.Utc).AddTicks(6738), "SALE-RULE3", 1600m },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("35c9c835-a464-4296-8b6e-adfe7ce2a516"), "Branch D", new Guid("812ff1cf-5d40-407a-a4e5-188076369690"), "Rule: > 20 items (invalid case)", false, new DateTime(2025, 4, 16, 12, 59, 24, 689, DateTimeKind.Utc).AddTicks(6740), "SALE-RULE4", 0m }
                });

            migrationBuilder.InsertData(
                table: "SaleItems",
                columns: new[] { "Id", "Discount", "IsCancelled", "ProductId", "ProductName", "Quantity", "SaleId", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("aaa10001-0000-0000-0000-000000000001"), 0m, false, new Guid("c66c053c-de32-4189-93c7-2892c64da20e"), "Mouse", 2, new Guid("33333333-3333-3333-3333-333333333333"), 150m },
                    { new Guid("aaa10002-0000-0000-0000-000000000002"), 0.1m, false, new Guid("79e04c8c-f8ea-4963-a317-048086cce4b9"), "Keyboard", 6, new Guid("44444444-4444-4444-4444-444444444444"), 150m },
                    { new Guid("aaa10003-0000-0000-0000-000000000003"), 0.2m, false, new Guid("87822321-e6e5-43f5-b541-9386e7fd48b0"), "Headset", 10, new Guid("55555555-5555-5555-5555-555555555555"), 200m },
                    { new Guid("aaa10004-0000-0000-0000-000000000004"), 0m, false, new Guid("4ebe432e-d89c-4e23-8d35-8c5073a4ac2a"), "Webcam", 25, new Guid("66666666-6666-6666-6666-666666666666"), 300m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("40bb13df-55ae-465b-a7bb-117eb03407b5"));

            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("845d8ece-9c6b-4e1f-930c-fd6a136ca4b6"));

            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("aaa10001-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("aaa10002-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("aaa10003-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "SaleItems",
                keyColumn: "Id",
                keyValue: new Guid("aaa10004-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.InsertData(
                table: "SaleItems",
                columns: new[] { "Id", "Discount", "IsCancelled", "ProductId", "ProductName", "Quantity", "SaleId", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("4968d1f2-798a-4ee7-95f2-f9037e7ba498"), 0m, false, new Guid("7e271c75-2bf6-45e3-8612-4c2725263757"), "Gamer Mouse", 3, new Guid("22222222-2222-2222-2222-222222222222"), 100m },
                    { new Guid("75bce800-b422-4249-874e-0a8d4f83bc12"), 0.2m, false, new Guid("305a0d13-203e-445b-a96c-f4d0c4eeaf00"), "LED Monitor", 15, new Guid("11111111-1111-1111-1111-111111111111"), 400m }
                });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "BranchId", "CustomerId", "SaleDate" },
                values: new object[] { new Guid("2af37d97-9fd7-40fe-b9fb-94af36926c5b"), new Guid("7c443f17-cb02-491a-b773-fad061eb4281"), new DateTime(2025, 4, 16, 12, 53, 12, 413, DateTimeKind.Utc).AddTicks(1927) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "BranchId", "CustomerId", "SaleDate" },
                values: new object[] { new Guid("375b86be-c378-4ee2-87e9-f037be7d5db5"), new Guid("a4720f2a-17f5-446d-8785-360d9baa5e7b"), new DateTime(2025, 4, 16, 12, 53, 12, 413, DateTimeKind.Utc).AddTicks(1958) });
        }
    }
}
