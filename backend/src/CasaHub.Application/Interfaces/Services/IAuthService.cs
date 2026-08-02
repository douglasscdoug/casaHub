using CasaHub.Application.DTOs.Auth;

namespace CasaHub.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken);
    }
}