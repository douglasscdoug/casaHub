using CasaHub.Application.DTOs.Users;

namespace CasaHub.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateAsync(CreateUserRequestDto request, CancellationToken cancellationToken);
    }
}