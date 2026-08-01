using CasaHub.Domain.Entities;

namespace CasaHub.Application.Contracts.Security
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}