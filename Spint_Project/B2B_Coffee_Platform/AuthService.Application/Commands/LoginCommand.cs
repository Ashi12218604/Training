using System;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Domain.Interfaces;
using AuthService.Application.Interfaces; // <-- This is the magic line that fixes the error!
using MediatR;

namespace AuthService.Application.Commands
{
    // ─── Result DTO ───────────────────────────────────────────────────────────────
    public record LoginResult(string Token, string Role, Guid UserId, string FullName);

    // ─── Request ──────────────────────────────────────────────────────────────────
    public record LoginCommand(string Email, string Password) : IRequest<LoginResult>;

    // ─── Handler ──────────────────────────────────────────────────────────────────
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtService;

        public LoginCommandHandler(IUserRepository userRepository, IJwtTokenService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // 1. Find user by email
            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (user is null)
                throw new UnauthorizedAccessException("Invalid email or password.");

            // 2. Verify password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
                throw new UnauthorizedAccessException("Invalid email or password.");

            // 3. Generate JWT
            // Note: Since user.Role is already a string in your entity, we don't need .ToString() here
            var token = _jwtService.GenerateToken(user.Id, user.Email, user.Role.ToString());

            return new LoginResult(token, user.Role.ToString(), user.Id, user.FullName);
        }
    }
}