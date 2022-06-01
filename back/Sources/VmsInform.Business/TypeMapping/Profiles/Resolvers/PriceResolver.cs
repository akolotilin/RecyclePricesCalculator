using AutoMapper;
using System;
using VmsInform.Business.Services;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.TypeMapping.Profiles.Resolvers
{
    internal sealed class PriceResolver : IValueResolver<GoodSurcharge, PriceItemData, PriceDto>
    {
        private readonly IPricesService _pricesService;

        public PriceResolver(IPricesService pricesService)
        {
            _pricesService = pricesService ?? throw new ArgumentNullException(nameof(pricesService));
        }

        public PriceDto Resolve(GoodSurcharge source, PriceItemData destination, PriceDto destMember, ResolutionContext context)
        {
            return _pricesService.CalcPrice(source.GoodId, source.Surcharge, source.PriceType.IsTransit).Result;
        }
    }
}
