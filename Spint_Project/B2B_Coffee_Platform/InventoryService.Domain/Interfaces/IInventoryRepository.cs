using System;
using System.Threading;
using System.Threading.Tasks;
using InventoryService.Domain.Entities;

namespace InventoryService.Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task<InventoryItem?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
        Task AddAsync(InventoryItem item, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}