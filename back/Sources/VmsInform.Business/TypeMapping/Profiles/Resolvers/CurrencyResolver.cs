using AutoMapper;
using System;
using VmsInform.Business.Services;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.TypeMapping.Profiles.Resolvers
{
    internal sealed class CurrencyResolver : IValueResolver<Good, PricesEditGoodDto, string>
    {
        private readonly IPricesService _pricesService;

        public CurrencyResolver(IPricesService pricesService)
        {
            _pricesService = pricesService ?? throw new ArgumentNullException(nameof(pricesService));
        }

        public string Resolve(Good source, PricesEditGoodDto destination, string destMember, ResolutionContext context)
        {
            return _pricesService.GetGoodPrice(source).Currency?.Code ?? "RUR";
        }
    }
}
