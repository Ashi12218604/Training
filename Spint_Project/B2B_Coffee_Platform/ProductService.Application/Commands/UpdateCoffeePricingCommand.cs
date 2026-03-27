using MediatR;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Commands
{
    // ─── The Request ──────────────────────────────────────────────────────────────
    // Returns true if updated, false if product not found
    public record UpdateCoffeePricingCommand(Guid Id, decimal NewCartonPrice) : IRequest<bool>;

    // ─── The Handler ──────────────────────────────────────────────────────────────
    public class UpdateCoffeePricingCommandHandler : IRequestHandler<UpdateCoffeePricingCommand, bool>
    {
        private readonly IProductRepository _repository;

        public UpdateCoffeePricingCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCoffeePricingCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (product is null) return false;

            // Domain method enforces business rule: price must be > 0
            product.UpdatePricing(request.NewCartonPrice);

            await _repository.UpdateAsync(product, cancellationToken);
            return true;
        }
    }
}
