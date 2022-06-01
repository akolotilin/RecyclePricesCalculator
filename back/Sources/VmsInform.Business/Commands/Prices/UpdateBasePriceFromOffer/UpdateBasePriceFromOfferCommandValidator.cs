using FluentValidation;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Commands.Prices.UpdateBasePriceFromOffer
{
    internal sealed class UpdateBasePriceFromOfferCommandValidator : AbstractValidator<UpdateBasePriceFromOfferCommand>
    {
        public UpdateBasePriceFromOfferCommandValidator(IValidator<PartnerPriceOfferDto> offerValidator)
        {
            RuleFor(a => a.Offer)
                .NotNull()
                .SetValidator(offerValidator);

            RuleFor(a => a.GoodId)
                .GreaterThan(0);
        }
    }
}
