using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Interfaces;

namespace InventoryService.Application.Commands
{
    // QuantityChange can be positive (adding stock) or negative (someone bought coffee)
    public record AdjustStockCommand(Guid ProductId, int QuantityChange) : IRequest<bool>;

    public class AdjustStockCommandHandler : IRequestHandler<AdjustStockCommand, bool>
    {
        private readonly IInventoryRepository _repository;

        public AdjustStockCommandHandler(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AdjustStockCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByProductIdAsync(request.ProductId, cancellationToken);

            if (item == null)
            {
                // If it doesn't exist yet, create it with the incoming stock
                if (request.QuantityChange < 0) throw new Exception("Cannot reduce stock for a product that has no inventory record.");

                item = new InventoryItem(request.ProductId, request.QuantityChange);
                await _repository.AddAsync(item, cancellationToken);
            }
            else
            {
                // If it exists, adjust the stock
                item.AdjustStock(request.QuantityChange);
            }

            await _repository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}