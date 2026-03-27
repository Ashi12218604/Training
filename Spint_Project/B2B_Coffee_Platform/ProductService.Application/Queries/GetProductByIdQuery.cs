using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Queries
{
    // ─── The Request ──────────────────────────────────────────────────────────────
    public record GetProductByIdQuery(Guid Id) : IRequest<CoffeeProduct?>;

    // ─── The Handler ──────────────────────────────────────────────────────────────
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, CoffeeProduct?>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoffeeProduct?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
