    using AutoMapper;
using System;
using System.Linq;
using VmsInform.Business.TypeMapping.Profiles.Resolvers;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal sealed class PricesProfile : Profile
    {
        public PricesProfile()
        {
            CreateMap<PriceType, PriceTypeDto>();
            CreateMap<Good, PricesEditGoodDto>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(a => a.IsGroup, opt => opt.MapFrom(src => false))
                .ForMember(a => a.BasePrice, opt => opt.MapFrom<BasePriceResolver>())
                .ForMember(a => a.Prices, opt => opt.MapFrom(src => src.GoodSurcharges.ToDictionary(a => a.PriceTypeId, a => a)))
                .ForMember(a => a.PriceDetails, opt => opt.MapFrom<PriceDetailsResolver>())
                .ForMember(a => a.InputPriceManual, opt => opt.MapFrom(src => src.InputPriceManual))
                .ForMember(a => a.BaseGood, opt => opt.MapFrom(src => MapBaseGood(src.BaseGoodRule)))
                .ForMember(a => a.Currency, opt => opt.MapFrom<CurrencyResolver>());

            CreateMap<GoodSurcharge, PriceItemData>()
                .ForMember(a => a.Surcharge, opt => opt.MapFrom(src => src.Surcharge))
                .ForMember(a => a.Price, opt => opt.MapFrom<PriceResolver>());

            CreateMap<PartnerGoodsToSell, PartnerPriceOfferDto>()
                .ForMember(a => a.PartnerId, opt => opt.MapFrom(src => src.PartnerId))
                .ForMember(a => a.PartnerName, opt => opt.MapFrom(src => src.Partner.Name))
                .ForMember(a => a.FactoryId, opt => opt.MapFrom(src => MapFactoryId(src.Factory)))
                .ForMember(a => a.FactoryName, opt => opt.MapFrom(src => MapFactoryName(src.Factory)))
                .ForMember(a => a.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(a => a.Currency, opt => opt.MapFrom(src => MapCurrency(src.Currency)))
                .ForMember(a => a.ValidThru, opt => opt.MapFrom(src => src.ValidThru.ToString("yyyy-MM-dd")))
                .ForMember(a => a.IsActual, opt => opt.MapFrom(src => src.ValidThru >= DateTime.Today.AddDays(1)))
                .ForMember(a => a.IsBest, opt => opt.MapFrom<OfferIsBestResolver>());
        }

        private static string MapBaseGood (BaseGoodRule rule)
        {
            return rule?.BaseGood?.Name;
        }

        private static string MapFactoryName(Factory factory)
        {
            return factory.Name;
        }

        private static long? MapFactoryId(Factory factory)
        {
            return factory?.Id;
        }

        private static string MapCurrency(Currency currency)
        {
            return currency?.Code ?? "RUR";
        }
    }
}
