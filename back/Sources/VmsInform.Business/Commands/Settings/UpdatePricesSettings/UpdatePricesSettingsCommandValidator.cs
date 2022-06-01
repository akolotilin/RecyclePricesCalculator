using FluentValidation;

namespace VmsInform.Business.Commands.Settings.UpdatePricesSettings
{
    internal sealed class UpdatePricesSettingsCommandValidator : AbstractValidator<UpdatePricesSettingsCommand>
    {
        public UpdatePricesSettingsCommandValidator()
        {
            RuleFor(a => a.Cash)
                .InclusiveBetween(0, 100);

            RuleFor(a => a.Transport)
                .GreaterThanOrEqualTo(0);
        }
    }
}
