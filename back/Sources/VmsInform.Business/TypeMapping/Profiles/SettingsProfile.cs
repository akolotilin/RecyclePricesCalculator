using AutoMapper;
using VmsInform.Business.Commands.Settings.UpdatePricesSettings;
using VmsInform.DAL;
using VmsInform.Web.Dto.Settings;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal sealed class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<IGlobalSettings, PriceSettingsDto>()
                .ForMember(a => a.Cash, opt => opt.MapFrom(src => src.Cash))
                .ForMember(a => a.Transport, opt => opt.MapFrom(src => src.Transport));

            CreateMap<UpdatePricesSettingsCommand, IGlobalSettings>();
        }
    }
}
