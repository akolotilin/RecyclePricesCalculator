using FluentValidation;

namespace VmsInform.Common.Commands.Users.AuthUser
{
    internal sealed class AuthUserCommandValidator : AbstractValidator<AuthUserCommand>
    {
        public AuthUserCommandValidator()
        {
            RuleFor(a => a.EMail)
                .NotEmpty();

            RuleFor(a => a.Password)
                .NotEmpty();
        }
    }
}
