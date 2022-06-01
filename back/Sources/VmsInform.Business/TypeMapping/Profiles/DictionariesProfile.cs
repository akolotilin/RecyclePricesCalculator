using AutoMapper;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal sealed class DictionariesProfile : Profile
    {
        public DictionariesProfile()
        {
            CreateMap<Currency, NamedObjectDto>()
                .IncludeBase<NamedObject, NamedObjectDto>()
                .ForMember(a => a.Code, opt => opt.MapFrom(src => src.Code));
        }
    }
}
