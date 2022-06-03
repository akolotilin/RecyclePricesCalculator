using AutoMapper;
using System.Linq;
using VmsInform.Business.Commands.Shipments.AddShipment;
using VmsInform.Business.TypeMapping.Profiles.Resolvers;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal sealed class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {
            CreateMap<BaseShipmentDto, Shipment>()
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment ?? string.Empty))
                .ForMember(a => a.ShipmentDate, opt => opt.MapFrom(src => src.ShipmentDate))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<AddShipmentCommand, Shipment>()
                .IncludeBase<BaseShipmentDto, Shipment>()
                .ForMember(a => a.Pictures, opt => opt.MapFrom<ShipmentPicturesResolver>())
                .ForMember(a => a.PartnerId, opt => opt.MapFrom(src => src.PartnerId))
                .ForMember(a => a.FactoryId, opt => opt.MapFrom(src => src.FactoryId));

            CreateMap<Shipment, ShipmentDto>()
                .ForMember(a => a.ShipmentDate, opt => opt.MapFrom(src => src.ShipmentDate))
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.EditInfo, opt => opt.MapFrom(src => src))
                .ForMember(a => a.Partner, opt => opt.MapFrom(src => src.Partner.Name))
                .ForMember(a => a.Factory, opt => opt.MapFrom(src => src.Factory));

            CreateMap<Shipment, EditShipmentDto>()
                .ForMember(a => a.ShipmentDate, opt => opt.MapFrom(src => src.ShipmentDate))
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(a => a.PartnerId, opt => opt.MapFrom(src => src.PartnerId))
                .ForMember(a => a.FactoryId, opt => opt.MapFrom(src => src.FactoryId))
                .ForMember(a => a.Pictures, opt => opt.MapFrom(src => src.Pictures.Select(x => x.Id)));


            CreateMap<EditShipmentDto, Shipment>()
                .ForMember(a => a.ShipmentDate, opt => opt.MapFrom(src => src.ShipmentDate))
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(a => a.PartnerId, opt => opt.MapFrom(src => src.PartnerId))
                .ForMember(a => a.FactoryId, opt => opt.MapFrom(src => src.FactoryId))
                .ForMember(a => a.Pictures, opt => opt.MapFrom<ShipmentPicturesResolver>())
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
