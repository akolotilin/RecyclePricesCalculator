using AutoMapper;
using System;
using System.Linq;
using VmsInform.Business.Commands.Partners.AddPartner;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal sealed class PartnersProfile : Profile
    {
        public PartnersProfile()
        {
            CreateMap<AddPartnerCommand, Partner>()
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment));

            CreateMap<PartnerContactDto, PartnerContact>();
            CreateMap<PartnerContact, PartnerContactDto>();

            CreateMap<Partner, PartnerDto>()
                .ForMember(a => a.Phone, opt => opt.MapFrom(
                      src => src.Contacts
                      .Where(c => c.ContactType == ContactType.CellPhone)
                      .Select(a => a.ContactData)
                      .DefaultIfEmpty(string.Empty)
                      .Aggregate((a, b) => a + ", " + b)))
                .ForMember(a => a.EMail, opt => opt.MapFrom(
                    src => src.Contacts
                    .Where(c => c.ContactType == ContactType.Email)
                    .Select(c => c.ContactData)
                    .DefaultIfEmpty(string.Empty)
                    .Aggregate((a, b) => a + ", " + b)));

            CreateMap<Partner, EditPartnerDto>();

            CreateMap<EditPartnerDto, Partner>()
                //.ForMember(a => a.GoodsToSell, opt => opt.MapFrom<GoodsToSellResolver>())
                ;

            CreateMap<PartnerShipmentAddress, ShipmentAddressDto>();
            CreateMap<ShipmentAddressDto, PartnerShipmentAddress>();

            CreateMap<PartnerGoodsToSell, GoodToSellDto>()
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Good.Name))
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.GoodId))
                .ForMember(a => a.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(a => a.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(a => a.IsActive, opt => opt.MapFrom(a => a.ValidThru > DateTime.Today))
                .ForMember(a => a.ValidThru, opt => opt.MapFrom(src => src.ValidThru));

            CreateMap<GoodToSellDto, PartnerGoodsToSell>()
                .ForMember(a => a.GoodId, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(a => a.ValidThru, opt => opt.MapFrom(src => src.ValidThru))
                .ForMember(a => a.CurrencyId, opt => opt.MapFrom(src => src.Currency.Id))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
