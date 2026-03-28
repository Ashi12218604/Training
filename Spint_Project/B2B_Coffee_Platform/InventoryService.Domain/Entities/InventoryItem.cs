using System;

namespace InventoryService.Domain.Entities
{
    public class InventoryItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int StockQuantity { get; private set; }

        private InventoryItem() { } // EF Core requirement

        public InventoryItem(Guid productId, int initialStock)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            StockQuantity = initialStock;
        }

        public void AdjustStock(int quantityChange)
        {
            if (StockQuantity + quantityChange < 0)
                throw new InvalidOperationException("Cannot reduce stock below zero. Insufficient inventory.");

            StockQuantity += quantityChange;
        }
    }
}