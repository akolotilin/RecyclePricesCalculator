using FluentValidation;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Validators
{
    internal sealed class PartnerPriceOfferDtoValidator : AbstractValidator<PartnerPriceOfferDto>
    {
        public PartnerPriceOfferDtoValidator()
        {
            RuleFor(a => a.Currency)
                .NotEmpty();

            RuleFor(a => a.Price)
                .GreaterThan(0);
        }
    }
}
