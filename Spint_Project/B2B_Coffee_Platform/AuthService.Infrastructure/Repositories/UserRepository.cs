using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var normalizedEmail = email.ToLowerInvariant();

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == normalizedEmail, cancellationToken);
        }

        public async Task AddAsync(AppUser user, CancellationToken cancellationToken)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> AnyUsersExistAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(cancellationToken);
        }

        // 👇 THIS IS THE NEW METHOD THAT FIXES YOUR ERROR 👇
        public async Task<IEnumerable<AppUser>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking() // Makes the query much faster since we are just reading data!
                .ToListAsync(cancellationToken);
        }
    }
}