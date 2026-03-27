using ProductService.Domain.Entities;

namespace ProductService.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(CoffeeProduct product, CancellationToken cancellationToken);
        Task<IEnumerable<CoffeeProduct>> GetAllActiveAsync(CancellationToken cancellationToken);
        Task<CoffeeProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(CoffeeProduct product, CancellationToken cancellationToken);
    }
}
