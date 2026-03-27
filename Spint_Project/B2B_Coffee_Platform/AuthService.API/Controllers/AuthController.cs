using AuthService.Application.Commands;
using AuthService.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ──────────────────────────────────────────────────────────────────────────
        // POST /api/auth/login  — PUBLIC (no token needed)
        // ──────────────────────────────────────────────────────────────────────────
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        // ──────────────────────────────────────────────────────────────────────────
        // POST /api/auth/register  — PROTECTED (Superadmin or Admin only)
        // ──────────────────────────────────────────────────────────────────────────
        [HttpPost("register")]
        [Authorize(Roles = "Superadmin,Admin")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                // Read the calling user's identity from the JWT token
                var requestingUserIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    ?? User.FindFirstValue(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub);

                var requestingUserRoleStr = User.FindFirstValue(ClaimTypes.Role);

                if (!Guid.TryParse(requestingUserIdStr, out var requestingUserId))
                    return Unauthorized(new { message = "Invalid token claims." });

                if (!Enum.TryParse<UserRole>(requestingUserRoleStr, out var requestingRole))
                    return Unauthorized(new { message = "Invalid role in token." });

                var command = new RegisterUserCommand(
                    request.FullName,
                    request.Email,
                    request.Password,
                    request.RoleToAssign,
                    requestingUserId,
                    requestingRole
                );

                var newUserId = await _mediator.Send(command);
                return StatusCode(201, new { userId = newUserId, message = "User created successfully." });
            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(403, new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
    }

    // ─── Request DTO (separate from the MediatR command for cleanliness) ──────────
    public record RegisterRequest(string FullName, string Email, string Password, UserRole RoleToAssign);
}
