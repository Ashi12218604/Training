using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(Guid userId, string email, string role);
    }
}
