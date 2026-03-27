using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderService.Domain.Entities;
using OrderService.Domain.Interfaces;

namespace OrderService.Application.Commands
{
    // ─── Simplified Request (Frontend only sends ID and Quantity!) ──────────
    public record OrderItemRequestDto(Guid ProductId, int Quantity);
    public record CreateOrderCommand(Guid UserId, List<OrderItemRequestDto> Items) : IRequest<Guid>;

    // ─── Internal DTO to catch the Product Service response ─────────────────
    public record ProductResponseDto(Guid Id, string Sku, string Name, decimal Price);

    // ─── Handler ────────────────────────────────────────────────────────────
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IHttpClientFactory httpClientFactory)
        {
            _orderRepository = orderRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.UserId);

            // Create the client to talk to the Product Service
            var productClient = _httpClientFactory.CreateClient("ProductClient");

            foreach (var item in request.Items)
            {
                // 1. HTTP GET to the Product Service to verify the item exists and get the REAL price
                var response = await productClient.GetAsync($"api/Products/{item.ProductId}", cancellationToken);

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Product with ID {item.ProductId} not found in the Catalog.");

                var productInfo = await response.Content.ReadFromJsonAsync<ProductResponseDto>(cancellationToken: cancellationToken);

                if (productInfo == null)
                    throw new Exception("Failed to parse product data.");

                // 2. Add the item to the order using the TRUSTED data from the Product Service
                order.AddItem(productInfo.Id, productInfo.Sku, productInfo.Name, productInfo.Price, item.Quantity);
            }

            await _orderRepository.AddAsync(order, cancellationToken);
            await _orderRepository.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}