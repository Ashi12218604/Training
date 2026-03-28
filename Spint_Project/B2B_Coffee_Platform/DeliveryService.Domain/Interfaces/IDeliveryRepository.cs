using System;
using System.Threading;
using System.Threading.Tasks;
using DeliveryService.Domain.Entities;

namespace DeliveryService.Domain.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<Delivery?> GetByOrderIdAsync(Guid orderId, CancellationToken cancellationToken);
        Task<Delivery?> GetByTrackingNumberAsync(string trackingNumber, CancellationToken cancellationToken);
        Task AddAsync(Delivery delivery, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}