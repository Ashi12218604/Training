using System;
using DeliveryService.Domain.Enums;

namespace DeliveryService.Domain.Entities
{
    public class Delivery
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public string TrackingNumber { get; private set; }
        public DeliveryStatus Status { get; private set; }
        public DateTime? EstimatedDeliveryDate { get; private set; }

        private Delivery() { } // EF Core requirement

        public Delivery(Guid orderId)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            // Generate a fake realistic tracking number
            TrackingNumber = $"TRK-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
            Status = DeliveryStatus.Pending;
            EstimatedDeliveryDate = DateTime.UtcNow.AddDays(3); // Standard 3-day shipping
        }

        public void UpdateStatus(DeliveryStatus newStatus)
        {
            Status = newStatus;
        }
    }
}