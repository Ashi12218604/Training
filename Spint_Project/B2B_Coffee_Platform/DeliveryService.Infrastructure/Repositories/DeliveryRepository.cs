using System;
using System.Threading;
using System.Threading.Tasks;
using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Interfaces;
using DeliveryService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Infrastructure.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DeliveryDbContext _context;

        public DeliveryRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery?> GetByOrderIdAsync(Guid orderId, CancellationToken cancellationToken)
        {
            return await _context.Deliveries.FirstOrDefaultAsync(d => d.OrderId == orderId, cancellationToken);
        }

        public async Task<Delivery?> GetByTrackingNumberAsync(string trackingNumber, CancellationToken cancellationToken)
        {
            return await _context.Deliveries.FirstOrDefaultAsync(d => d.TrackingNumber == trackingNumber, cancellationToken);
        }

        public async Task AddAsync(Delivery delivery, CancellationToken cancellationToken)
        {
            await _context.Deliveries.AddAsync(delivery, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}