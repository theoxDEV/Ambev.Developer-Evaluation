using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    /// <summary>
    /// Query for retrieving all sales from the database.
    /// </summary>
    /// <remarks>
    /// This query does not perform any state-changing operations and follows CQRS principles.
    /// The result is a list of sales with basic metadata like sale number, branch, and total.
    /// </remarks>
    public class GetAllSalesQuery : IRequest<List<GetAllSalesResponse>>
    {
    }
}
