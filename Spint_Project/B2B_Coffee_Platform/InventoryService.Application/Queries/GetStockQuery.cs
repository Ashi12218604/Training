using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using InventoryService.Domain.Interfaces;

namespace InventoryService.Application.Queries
{
    public record StockResponseDto(Guid ProductId, int StockQuantity);

    public record GetStockQuery(Guid ProductId) : IRequest<StockResponseDto>;

    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, StockResponseDto>
    {
        private readonly IInventoryRepository _repository;

        public GetStockQueryHandler(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<StockResponseDto> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByProductIdAsync(request.ProductId, cancellationToken);

            // If we don't have a record, assume 0 stock
            return new StockResponseDto(request.ProductId, item?.StockQuantity ?? 0);
        }
    }
}