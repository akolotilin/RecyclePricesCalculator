using FluentValidation;

namespace VmsInform.Common.Commands.Misc.SendEMail
{
    internal sealed class SendEMailCommandValidator : AbstractValidator<SendEMailCommand>
    {
        public SendEMailCommandValidator()
        {
            RuleFor(a => a.EMail)
                .EmailAddress()
                .NotEmpty();

            RuleFor(a => a.Subject)
                .NotEmpty();

            RuleFor(a => a.Body)
                .NotEmpty();
        }
    }
}
