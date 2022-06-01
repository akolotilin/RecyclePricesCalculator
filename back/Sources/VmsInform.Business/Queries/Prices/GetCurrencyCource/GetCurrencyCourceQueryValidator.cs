using FluentValidation;

namespace VmsInform.Business.Queries.Prices.GetCurrencyCource
{
    internal sealed class GetCurrencyCourceQueryValidator : AbstractValidator<GetCurrencyCourceQuery>
    {
        public GetCurrencyCourceQueryValidator()
        {
            RuleFor(a => a.Code)
                .NotEmpty();
        }
    }
}
