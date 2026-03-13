using Microsoft.AspNetCore.Mvc;
using SecureTaskAPI.Services;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Data;
using System.Linq;

namespace SecureTaskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenService _jwt;

        public AuthController(AppDbContext context, JwtTokenService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email && u.Name == dto.Name);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _jwt.GenerateToken(user.Name);

            return Ok(new
            {
                Token = token
            });
        }
    }
}