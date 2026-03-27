using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderService.Domain.Interfaces;

namespace OrderService.Application.Queries
{
    // ─── DTOs (Data Transfer Objects) ─────────────────────────────────────────
    public record OrderResponseDto(Guid Id, DateTime OrderDate, string Status, decimal TotalAmount, List<OrderItemResponseDto> Items);
    public record OrderItemResponseDto(string ProductName, int Quantity, decimal UnitPrice, decimal TotalPrice);

    // ─── Request ──────────────────────────────────────────────────────────────
    public record GetMyOrdersQuery(Guid UserId) : IRequest<List<OrderResponseDto>>;

    // ─── Handler ──────────────────────────────────────────────────────────────
    public class GetMyOrdersQueryHandler : IRequestHandler<GetMyOrdersQuery, List<OrderResponseDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetMyOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderResponseDto>> Handle(GetMyOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(request.UserId, cancellationToken);

            return orders.Select(o => new OrderResponseDto(
                o.Id,
                o.OrderDate,
                o.Status.ToString(),
                o.TotalAmount,
                o.Items.Select(i => new OrderItemResponseDto(i.ProductName, i.Quantity, i.UnitPrice, i.TotalPrice)).ToList()
            )).ToList();
        }
    }
}