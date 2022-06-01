using FluentValidation;

namespace VmsInform.Common.Commands.Users.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(a => a.UserId)
                .GreaterThan(0);

            RuleFor(a => a.NewPassword)
                .NotEmpty();
        }
    }
}
