using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleByIdQuery : IRequest<GetSaleByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
