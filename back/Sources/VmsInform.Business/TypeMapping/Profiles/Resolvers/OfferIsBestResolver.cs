using AutoMapper;
using System;
using System.Linq;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.TypeMapping.Profiles.Resolvers
{
    internal sealed class OfferIsBestResolver : IValueResolver<PartnerGoodsToSell, PartnerPriceOfferDto, bool>
    {
        private readonly IVmsInformRepository<PartnerGoodsToSell> _goodsToSellRepository;

        public OfferIsBestResolver(IVmsInformRepository<PartnerGoodsToSell> goodsToSellRepository)
        {
            _goodsToSellRepository = goodsToSellRepository ?? throw new ArgumentNullException(nameof(goodsToSellRepository));
        }

        public bool Resolve(PartnerGoodsToSell source, PartnerPriceOfferDto destination, bool destMember, ResolutionContext context)
        {
            return _goodsToSellRepository.Query()
                .Where(a => a.GoodId == source.GoodId && a.Id != source.Id)
                .Where(a => a.ValidThru > DateTime.Today)
                .All(a => a.Price < source.Price);
        }
    }
}
