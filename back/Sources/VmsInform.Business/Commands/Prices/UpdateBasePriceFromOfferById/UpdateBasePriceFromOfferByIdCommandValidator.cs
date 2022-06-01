using FluentValidation;

namespace VmsInform.Business.Commands.Prices.UpdateBasePriceFromOfferById
{
    internal sealed class UpdateBasePriceFromOfferByIdCommandValidator : AbstractValidator<UpdateBasePriceFromOfferByIdCommand>
    {
        public UpdateBasePriceFromOfferByIdCommandValidator()
        {
            RuleFor(a => a.OfferId)
                .GreaterThan(0);
        }
    }
}
