using AuthService.Domain.Entities;
using AuthService.Domain.Enums;
using AuthService.Domain.Interfaces;
using MediatR;

namespace AuthService.Application.Commands
{
    // ─── Request ───────────────────────────────────────────────────────────────────
    // Only Superadmin can create Admins.
    // Only Admins can create Clients.
    public record RegisterUserCommand(
        string FullName,
        string Email,
        string Password,
        UserRole RoleToAssign,
        Guid RequestingUserId,     // The Superadmin or Admin doing the creating
        UserRole RequestingUserRole // Their own role – validated here in handler
    ) : IRequest<Guid>;

    // ─── Handler ───────────────────────────────────────────────────────────────────
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // 1. Role permission check
            bool isAllowed =
                (request.RequestingUserRole == UserRole.Superadmin && request.RoleToAssign == UserRole.Admin) ||
                (request.RequestingUserRole == UserRole.Admin      && request.RoleToAssign == UserRole.Client);

            if (!isAllowed)
                throw new UnauthorizedAccessException(
                    "You do not have permission to create a user with that role.");

            // 2. Check email not already taken
            var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (existingUser is not null)
                throw new InvalidOperationException("A user with this email already exists.");

            // 3. Hash password with BCrypt
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 4. Create and save
            var newUser = new AppUser(
                request.FullName,
                request.Email,
                passwordHash,
                request.RoleToAssign,
                request.RequestingUserId
            );

            await _userRepository.AddAsync(newUser, cancellationToken);

            return newUser.Id;
        }
    }
}
