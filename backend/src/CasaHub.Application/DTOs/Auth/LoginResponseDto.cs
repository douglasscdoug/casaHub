using CasaHub.Application.DTOs.Users;

namespace CasaHub.Application.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }

        public UserResponseDto User { get; set; } = null!;
    }
}