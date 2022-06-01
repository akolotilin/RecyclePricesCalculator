using AutoMapper;
using System;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.TypeMapping.Profiles.Resolvers
{
    internal sealed class PriceDetailsResolver : IValueResolver<Good, PricesEditGoodDto, BasePriceDetailsDto>
    {
        public PriceDetailsResolver( )
        {

        }

        public BasePriceDetailsDto Resolve(Good source, PricesEditGoodDto destination, BasePriceDetailsDto destMember, ResolutionContext context)
        {
            return new BasePriceDetailsDto
            {
                ExpirationDate = source.BasePrice?.ExpirationDate?.ToShortDateString(),
                LastUpdated = source.BasePrice?.LastUpdated,
                Partner = source.BasePrice?.Partner?.Name ?? (source.BasePrice?.Price > 0 ? "<Введено вручную>" : null),
                Factory = source.BasePrice?.Factory?.Name,
                PartnerId = source.BasePrice?.PartnerId,
                IsExpired = source.BasePrice?.ExpirationDate < DateTime.Now
            };
        }
    }
}
