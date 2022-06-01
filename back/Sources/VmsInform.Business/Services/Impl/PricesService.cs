using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Services.Impl
{
    internal sealed class PricesService : IPricesService, IService
    {
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly decimal _cash;
        private readonly ICurrencyService _currencyService;

        private IEnumerable<Good> _goodsCache = null;

        public PricesService(IVmsInformRepository<Good> goodsRepository, IGlobalSettings globalSettings, ICurrencyService currencyService)
        {
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _cash = globalSettings?.Cash / 100.0M ?? throw new ArgumentNullException(nameof(globalSettings));
            _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
        }

        public async Task PreloadData()
        {
            _goodsCache = await IncludeAll(_goodsRepository.Query())
                .ToListAsync();
        }

        private async Task<Good> GetGoodData(long goodId)
        {
            return _goodsCache?.FirstOrDefault(a => a.Id == goodId) ?? await IncludeAll(_goodsRepository.Query()).FirstOrDefaultAsync(a => a.Id == goodId);
        }

        private IQueryable<Good> IncludeAll(IQueryable<Good> queryable)
        {
            return queryable.Include(a => a.BasePrice)
                .ThenInclude(a => a.Partner)
                .Include(a => a.BasePrice)
                .ThenInclude(a => a.Currency)
                .Include(a => a.BaseGoodRule);
        }

        public async Task<PriceDto> CalcPrice(long goodId, decimal surcharge, bool isTransit, CancellationToken cancellationToken = default(CancellationToken))
        {
            var good = await GetGoodData(goodId);

            var basePriceTuple = GetGoodPrice1(good);

            var basePrice = basePriceTuple.Price ?? 0M;

            if (basePriceTuple.Currency?.Code != "RUR" && basePriceTuple.Currency != null)
            {
                var cource = await _currencyService.GetCource(basePriceTuple.Currency.Code);
                basePrice = basePrice * cource;
            }

            var resultPriceCashless = basePrice - basePrice / 100M * surcharge;
            var resultPriceCash = resultPriceCashless - resultPriceCashless * _cash;
            
            var basePriceCashless = basePrice;
            var basePriceCash = basePrice - basePrice * _cash;

            if (!isTransit)
            {
                var transport = basePriceTuple.Partner?.TransportPrice ?? 0;
                resultPriceCash -= transport;
                resultPriceCashless -= transport;
                basePriceCash -= transport;
                basePriceCashless -= transport;
            }

            resultPriceCash = Math.Round(resultPriceCash / 1000.0M, 2);
            resultPriceCashless = Math.Round(resultPriceCashless / 1000.0M, 2);
            basePriceCash = Math.Round(basePriceCash / 1000.0M, 2);
            basePriceCashless = Math.Round(basePriceCashless / 1000.0M, 2);

            return new PriceDto
            {
                PriceCash = resultPriceCash,
                PriceCashless = resultPriceCashless,
                DeltaCash = basePriceCash - resultPriceCash,
                DeltaCashless = basePriceCashless - resultPriceCashless
            };
        }

        public (decimal? Price, Currency Currency) GetGoodPrice(Good good)
        {
            var result = GetGoodPrice1(good);
            return (result.Price, result.Currency);
        }

        private (decimal? Price, Currency Currency, Partner Partner) GetGoodPrice1(Good good)
        {
            return good.BaseGoodRule == null ? (good.BasePrice?.Price, good.BasePrice?.Currency, good.BasePrice?.Partner) : CalcBasePrice(good.BaseGoodRule);
        }

        private (decimal? Price, Currency Currency, Partner Partner) CalcBasePrice(BaseGoodRule rule)
        {
            var basePrice = GetGoodPrice1(rule.BaseGood);

            if (basePrice.Price.HasValue)
                return (Price: basePrice.Price.Value * rule.Multiplier + rule.Add, Currency: basePrice.Currency, Partner: basePrice.Partner);
            else
                return (null, null, null);
        }
    }
}
