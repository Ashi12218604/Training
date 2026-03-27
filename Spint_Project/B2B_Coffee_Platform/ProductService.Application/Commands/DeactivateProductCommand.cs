using MediatR;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Commands
{
    // ─── The Request ──────────────────────────────────────────────────────────────
    // Soft-delete: marks IsActive = false instead of deleting from DB
    public record DeactivateProductCommand(Guid Id) : IRequest<bool>;

    // ─── The Handler ──────────────────────────────────────────────────────────────
    public class DeactivateProductCommandHandler : IRequestHandler<DeactivateProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public DeactivateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeactivateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (product is null) return false;

            // Domain method sets IsActive = false
            product.DeactivateProduct();

            await _repository.UpdateAsync(product, cancellationToken);
            return true;
        }
    }
}
