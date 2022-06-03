using AutoMapper;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Factories;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal sealed class FactoryProfile : Profile
    {
        public FactoryProfile()
        {
            CreateMap<Factory, FactoryDto>();

            CreateMap<FactoryDto, Factory>()
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment ?? string.Empty));

            CreateMap<PartnerFactory, PartnerFactoryDto>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Factory.Id))
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Factory.Name))
                .ForMember(a => a.Address, opt => opt.MapFrom(src => src.Factory.Address))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PartnerFactoryDto, PartnerFactory>()
                .ForMember(a => a.FactoryId, opt => opt.MapFrom(src => src.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PartnerFactory, PartnerFactoryDto>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.FactoryId))
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Factory.Name))
                .ForMember(a => a.Address, opt => opt.MapFrom(src => src.Factory.Address));
        }
    }
}
