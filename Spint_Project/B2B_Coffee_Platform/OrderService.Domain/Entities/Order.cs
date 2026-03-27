using OrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; } // The Client who placed the order
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public decimal TotalAmount { get; private set; }

        // Navigation property for the items in this order
        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        // 1. EF Core Constructor
        private Order() { }

        // 2. Primary Constructor
        public Order(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            OrderDate = DateTime.UtcNow;
            Status = OrderStatus.Pending;
            TotalAmount = 0;
        }

        // Behavior Methods
        public void AddItem(Guid productId, string sku, string productName, decimal unitPrice, int quantity)
        {
            var item = new OrderItem(productId, sku, productName, unitPrice, quantity);
            _items.Add(item);
            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            TotalAmount = _items.Sum(i => i.TotalPrice);
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
