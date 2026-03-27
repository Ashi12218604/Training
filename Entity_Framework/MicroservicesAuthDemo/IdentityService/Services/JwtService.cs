using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IdentityService.Services
{
    public class JwtService
    {
        // 🔐 Keep this SAME as Gateway
        private const string SecretKey = "MY_ULTRA_SECRET_KEY_FOR_JWT_1234567890_SECURE_KEY_ABC";
        private const string Issuer = "AuthServer";
        private const string Audience = "Client";

        public string GenerateToken(string userId, string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // ✅ unique token id
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,              // ✅ token valid from now
                expires: DateTime.UtcNow.AddHours(2),    // ✅ expiry
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}