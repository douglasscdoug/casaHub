using CasaHub.Application.DTOs.Users;
using CasaHub.Application.Exceptions;
using CasaHub.Application.Interfaces.Repositories;
using CasaHub.Application.Interfaces.Security;
using CasaHub.Application.Interfaces.Services;
using CasaHub.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ApplicationValidationException = CasaHub.Application.Exceptions.ValidationException;

namespace CasaHub.Application.Services
{
    public class UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IValidator<CreateUserRequestDto> validator,
        ILogger<UserService> logger) : IUserService
    {
        public async Task<UserResponseDto> CreateAsync(CreateUserRequestDto request, CancellationToken cancellationToken)
        {
            logger.LogInformation( "Iniciando criação de usuário. Email: {Email}", request.Email);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                logger.LogWarning("Falha de validação ao criar usuário. Email: {Email}", request.Email);

                throw new ApplicationValidationException(validationResult.Errors.Select(error =>
                    new ValidationError(error.PropertyName, error.ErrorMessage)));
            }

            var emailExists = await userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

            if (emailExists)
            {
                logger.LogWarning(
                    "Tentativa de cadastro com e-mail já existente. Email: {Email}",
                    request.Email);

                throw new BusinessException("Já existe um usuário cadastrado com este e-mail.");
            }

            var passwordHash = passwordHasher.Hash(request.Password);

            var user = new User(request.Name, request.Email, passwordHash);

            await userRepository.AddAsync(user, cancellationToken);

            var success = await userRepository.SaveChangesAsync(cancellationToken);

            if (!success)
            {
                throw new PersistenceException("Não foi possível criar o usuário.");
            }

            logger.LogInformation("Usuário criado com sucesso. Id: {UserId}",user.Id);

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}