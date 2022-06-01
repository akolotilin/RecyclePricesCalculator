using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Services;

namespace VmsInform.Business.Queries.Prices.GetCurrencyCource
{
    internal sealed class GetCurrencyCourceQueryHandler : IRequestHandler<GetCurrencyCourceQuery, decimal>
    {
        private readonly ICurrencyService _currencyService;

        public GetCurrencyCourceQueryHandler(ICurrencyService currencyService)
        {
            _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
        }

        public async Task<decimal> Handle(GetCurrencyCourceQuery request, CancellationToken cancellationToken)
        {
            var cource = await _currencyService.GetCource(request.Code);
            return cource;
        }
    }
}
