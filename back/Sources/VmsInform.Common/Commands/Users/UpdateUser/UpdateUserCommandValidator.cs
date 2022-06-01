using FluentValidation;

namespace VmsInform.Common.Commands.Users.UpdateUser
{
    internal sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(a => a.User)
                .NotNull();
        }
    }
}
