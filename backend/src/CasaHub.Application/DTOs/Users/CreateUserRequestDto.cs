namespace CasaHub.Application.DTOs.Users
{
    public class CreateUserRequestDto
    {
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}