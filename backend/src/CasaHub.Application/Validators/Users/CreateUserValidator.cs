using CasaHub.Application.DTOs.Users;
using FluentValidation;

namespace CasaHub.Application.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequestDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(150);

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(100)
                .Matches("[A-Z]")
                .WithMessage("A senha deve conter uma letra maiúscula.")
                .Matches("[a-z]")
                .WithMessage("A senha deve conter uma letra minúscula.")
                .Matches("[0-9]")
                .WithMessage("A senha deve conter um número.")
                .Matches("[^a-zA-Z0-9]")
                .WithMessage("A senha deve conter um caractere especial.");
        }
    }
}