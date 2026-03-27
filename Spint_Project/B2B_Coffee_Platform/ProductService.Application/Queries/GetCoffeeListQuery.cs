using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Queries
{
    // The Request: We don't need to pass any parameters just to get the full list
    public record GetCoffeeListQuery() : IRequest<IEnumerable<CoffeeProduct>>;

    // The Handler: Fetches the data using our repository
    public class GetCoffeeListQueryHandler : IRequestHandler<GetCoffeeListQuery, IEnumerable<CoffeeProduct>>
    {
        private readonly IProductRepository _repository;

        public GetCoffeeListQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CoffeeProduct>> Handle(GetCoffeeListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllActiveAsync(cancellationToken);
        }
    }
}