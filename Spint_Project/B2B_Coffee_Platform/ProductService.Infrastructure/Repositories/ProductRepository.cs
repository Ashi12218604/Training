using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Persistence;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _context;

        public ProductRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CoffeeProduct product, CancellationToken cancellationToken)
        {
            _context.CoffeeProducts.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<CoffeeProduct>> GetAllActiveAsync(CancellationToken cancellationToken)
        {
            return await _context.CoffeeProducts
                                 .AsNoTracking()
                                 .ToListAsync(cancellationToken);
        }

        public async Task<CoffeeProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            // IgnoreQueryFilters lets us find deactivated products too (for admin use)
            return await _context.CoffeeProducts
                                 .IgnoreQueryFilters()
                                 .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(CoffeeProduct product, CancellationToken cancellationToken)
        {
            _context.CoffeeProducts.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
