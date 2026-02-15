using ERP.Core.Api.Models;
using ERP.Core.Api.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERP.Core.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwt;

        public AuthService(IOptions<JwtSettings> jwt)
        {
            _jwt = jwt.Value;
        }

        public LoginResponse Login(LoginRequest request)
        {
            // TEMP: hardcoded user (DB later)
            if (request.Username != "admin" || request.Password != "admin")
                throw new UnauthorizedAccessException("Invalid credentials");

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, "Admin")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.ExpiryMinutes),
                signingCredentials: creds
            );

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiry = token.ValidTo
            };
        }
    }
}
