using AutoMapper;
using System;
using VmsInform.Business.Services;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.TypeMapping.Profiles.Resolvers
{
    internal sealed class BasePriceResolver : IValueResolver<Good, PricesEditGoodDto, decimal?>
    {
        private readonly IPricesService _pricesService;

        public BasePriceResolver(IPricesService pricesService)
        {
            _pricesService = pricesService ?? throw new ArgumentNullException(nameof(pricesService));
        }

        public decimal? Resolve(Good source, PricesEditGoodDto destination, decimal? destMember, ResolutionContext context)
        {
            return _pricesService.GetGoodPrice(source).Price ?? 0;
        }
    }
}
