using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData
{
    public static class CreateSaleHandlerTestData
    {
        private static readonly Faker<CreateSaleCommand> saleCommandFaker = new Faker<CreateSaleCommand>()
            .RuleFor(s => s.CustomerName, f => f.Name.FullName()) // Nome do cliente
            .RuleFor(s => s.Items, f => new List<CreateSaleItemDto>
            {
            new CreateSaleItemDto
            {
                Description = f.Commerce.ProductName(),
                Price = f.Finance.Amount(10, 100),
                Quantity = f.Random.Int(1, 10)
            },
            new CreateSaleItemDto
            {
                Description = f.Commerce.ProductName(),
                Price = f.Finance.Amount(5, 50),
                Quantity = f.Random.Int(1, 10)
            }
            });

        /// <summary>
        /// Generates a valid CreateSaleCommand with randomized data.
        /// </summary>
        /// <returns>A CreateSaleCommand with valid randomized data.</returns>
        public static CreateSaleCommand GenerateValidCommand()
        {
            return saleCommandFaker.Generate();
        }
    }
}
