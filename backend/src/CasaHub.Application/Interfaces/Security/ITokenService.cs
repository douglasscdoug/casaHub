using CasaHub.Application.DTOs.Auth;
using CasaHub.Domain.Entities;

namespace CasaHub.Application.Interfaces.Security;

public interface ITokenService
{
    TokenResponseDto GenerateToken(User user);
}