using System;
using System.Threading;
using System.Threading.Tasks;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryDbContext _context;

        public InventoryRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<InventoryItem?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await _context.InventoryItems.FirstOrDefaultAsync(i => i.ProductId == productId, cancellationToken);
        }

        public async Task AddAsync(InventoryItem item, CancellationToken cancellationToken)
        {
            await _context.InventoryItems.AddAsync(item, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}