using AutoMapper;
using VmsInform.DAL.Domain;
using VmsInform.DAL.Domain.Common;
using VmsInform.Web.Dto.Common;
using VmsInform.Web.Dto.Goods;

namespace VmsInform.Common.TypeMapping.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<NamedObject, NamedObjectDto>();

            CreateMap<IEditorInfo, EditInfoDto>()
                .ForMember(a => a.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(a => a.Creator, opt => opt.MapFrom(src => src.Creator))
                .ForMember(a => a.Edited, opt => opt.MapFrom(src => src.LastEdit))
                .ForMember(a => a.LastEditor, opt => opt.MapFrom(src => src.LastEditor));

            CreateMap<Currency, CurrencyDto>();
        }
    }
}
