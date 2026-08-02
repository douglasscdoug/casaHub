using CasaHub.Application.DTOs.Users;
using CasaHub.Application.Interfaces.Repositories;
using CasaHub.Application.Interfaces.Security;
using CasaHub.Application.Interfaces.Services;
using CasaHub.Domain.Entities;
using FluentValidation;

namespace CasaHub.Application.Services
{
    public class UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IValidator<CreateUserRequestDto> validator) : IUserService
    {
        public async Task<UserResponseDto> CreateAsync(CreateUserRequestDto request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(
            request,
            cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var emailExists = await userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

            if (emailExists)
            {
                throw new InvalidOperationException(
                    "Já existe um usuário cadastrado com este e-mail.");
            }

            var passwordHash = passwordHasher.Hash(request.Password);

            var user = new User(request.Name, request.Email, passwordHash);

            await userRepository.AddAsync(user, cancellationToken);

            var success = await userRepository.SaveChangesAsync(cancellationToken);

            if (!success)
            {
                throw new InvalidOperationException(
                    "Não foi possível criar o usuário.");
            }

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}