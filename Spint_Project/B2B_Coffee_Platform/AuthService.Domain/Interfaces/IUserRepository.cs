using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task AddAsync(AppUser user, CancellationToken cancellationToken);

        // Used at startup to check if Superadmin seed is needed
        Task<bool> AnyUsersExistAsync(CancellationToken cancellationToken);
    }
}
