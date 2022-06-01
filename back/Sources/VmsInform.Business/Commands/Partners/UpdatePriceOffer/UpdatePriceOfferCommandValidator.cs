using FluentValidation;
using System;
using VmsInform.Common.Services;

namespace VmsInform.Business.Commands.Partners.UpdatePriceOffer
{
    internal sealed class UpdatePriceOfferCommandValidator : AbstractValidator<UpdatePriceOfferCommand>
    {
        public UpdatePriceOfferCommandValidator(ICurrencyService currencyService)
        {
            RuleFor(a => a.Currency)
                .NotEmpty()
                .MustAsync(async (code, ct) => (await currencyService.GetCurrencyByCode(code, ct)) != null)
                .WithMessage("Валюта не найдена");

            RuleFor(a => a.Price)
                .GreaterThan(0);

            RuleFor(a => a.ValidThru)
                .GreaterThanOrEqualTo(DateTime.Today.AddDays(1));
        }
    }
}
