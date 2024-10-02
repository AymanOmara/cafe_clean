using FluentValidation;

namespace Cafe.Application.Services.Authentication.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();

            RuleFor(x => x.Password).NotEmpty();

            RuleFor(x => x.Role).NotNull();
        }
    }
}

