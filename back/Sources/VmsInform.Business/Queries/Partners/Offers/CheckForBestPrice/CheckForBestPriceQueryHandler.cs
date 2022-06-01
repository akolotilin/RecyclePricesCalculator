using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Queries.Partners.Offers.CheckForBestPrice
{
    internal sealed class CheckForBestPriceQueryHandler : IRequestHandler<CheckForBestPriceQuery, bool>
    {
        private readonly IVmsInformRepository<PartnerGoodsToSell> _offersRepository;
        private readonly ICurrencyService _currencyService;
        private readonly IDateTimeService _dateTimeService;

        public CheckForBestPriceQueryHandler(IVmsInformRepository<PartnerGoodsToSell> offersRepository, ICurrencyService currencyService,
            IDateTimeService dateTimeService)
        {
            _offersRepository = offersRepository ?? throw new ArgumentNullException(nameof(offersRepository));
            _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public async Task<bool> Handle(CheckForBestPriceQuery request, CancellationToken cancellationToken)
        {
            var price = request.Price;

            if (request.Currency != "RUR")
                price = price * await _currencyService.GetCource(request.Currency);

            var otherOffers = await _offersRepository.Query()
                .Include(a => a.Currency)
                .Where(a => a.Id != request.OfferId && a.GoodId == request.GoodId)
                .Where(a => a.ValidThru > _dateTimeService.Today)
                .ToListAsync();

            var isBestPrice = !otherOffers.Any() || otherOffers.All(a => ConvertToRub(a) < price);

            return isBestPrice;
        }

        private decimal ConvertToRub(PartnerGoodsToSell offer)
        {
            if ((offer.Currency?.Code ?? "RUR") != "RUR")
                return offer.Price * _currencyService.GetCource(offer.Currency.Code).Result;

            return offer.Price;
        }
    }
}
