using CasaHub.Application.DTOs.Auth;
using CasaHub.Application.DTOs.Users;
using CasaHub.Application.Exceptions;
using CasaHub.Application.Interfaces.Repositories;
using CasaHub.Application.Interfaces.Security;
using CasaHub.Application.Interfaces.Services;
using FluentValidation;
using ApplicationValidationException = CasaHub.Application.Exceptions.ValidationException;

namespace CasaHub.Application.Services
{
    public class AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService,
        IValidator<LoginRequestDto> validator
    ) : IAuthService
    {
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ApplicationValidationException(
                    validationResult.Errors.Select(error => new ValidationError(
                        error.PropertyName,
                        error.ErrorMessage
                    ))
                );
            }

            var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (user is null)
            {
                throw new UnauthorizedException("Usuário ou senha inválidos.");
            }

            var passwordValid = passwordHasher.Verify(request.Password, user.PasswordHash);

            if (!passwordValid)
            {
                throw new UnauthorizedException("Usuário ou senha inválidos.");
            }

            var token = tokenService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token.Token,
                Expiration = token.Expiration,
                User = new UserResponseDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                }
            };
        }

    }
}