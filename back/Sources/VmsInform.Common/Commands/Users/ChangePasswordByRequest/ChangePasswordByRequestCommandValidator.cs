using FluentValidation;

namespace VmsInform.Common.Commands.ChangePasswordByRequest
{
    internal sealed class ChangePasswordByRequestCommandValidator : AbstractValidator<ChangePasswordByRequestCommand>
    {
        public ChangePasswordByRequestCommandValidator()
        {
            RuleFor(a => a.NewPassword)
                .NotEmpty();

            RuleFor(a => a.RequestKey)
                .NotEmpty();
        }
    }
}
