using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public string Sku { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        // Calculated property
        public decimal TotalPrice => UnitPrice * Quantity;

        // 1. EF Core Constructor
        private OrderItem() { }

        // 2. Primary Constructor
        public OrderItem(Guid productId, string sku, string productName, decimal unitPrice, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Sku = sku;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
