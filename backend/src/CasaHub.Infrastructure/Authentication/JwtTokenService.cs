using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CasaHub.Application.Contracts.Security;
using CasaHub.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CasaHub.Infrastructure.Authentication
{
    public class JwtTokenService(IOptions<JwtOptions> options) : ITokenService
    {
        private readonly JwtOptions _jwtOptions = options.Value;
        public string GenerateToken(User user)
        {
            var claims = GetClaims(user);

            var credentials = GetSigningCredentials();

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static IEnumerable<Claim> GetClaims(User user)
        {
            return
            [
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Name, user.Name),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);

            var securityKey = new SymmetricSecurityKey(key);

            return new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);
        }
    }
}