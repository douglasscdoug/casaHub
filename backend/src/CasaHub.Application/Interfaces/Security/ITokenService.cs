using CasaHub.Domain.Entities;

namespace CasaHub.Application.Interfaces.Security;

public interface ITokenService
{
    string GenerateToken(User user);
}