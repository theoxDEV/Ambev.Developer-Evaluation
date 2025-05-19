using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    /// <summary>
    /// Handler for the <see cref="GetAllSalesQuery"/> that retrieves all sales from the repository.
    /// </summary>
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesQuery, List<GetAllSalesResponse>>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesHandler"/> class.
        /// </summary>
        /// <param name="repository">The sale repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public GetAllSalesHandler(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the request to retrieve all sales.
        /// </summary>
        /// <param name="request">The <see cref="GetAllSalesQuery"/> query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of <see cref="GetAllSalesResponse"/>.</returns>
        public async Task<List<GetAllSalesResponse>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAllSalesResponse>>(sales);
        }
    }

}
