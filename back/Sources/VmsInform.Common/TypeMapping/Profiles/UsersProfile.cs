using AutoMapper;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.TypeMapping.Profiles
{
    internal sealed class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserSession, UserSessionAuthDto>()
                .ForMember(a => a.EMail, opt => opt.MapFrom(src => src.User.EMail))
                .ForMember(a => a.Token, opt => opt.MapFrom(src => src.SessionKey))
                .ForMember(a => a.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(a => a.IsAdmin, opt => opt.MapFrom(src => src.User.IsAdmin));

            CreateMap<UserSession, UserSessionDto>()
                .ForMember(a => a.Key, opt => opt.MapFrom(src => src.SessionKey))
                .ForMember(a => a.User, opt => opt.MapFrom(src => src.User));

            CreateMap<User, UserDto>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.EMail, opt => opt.MapFrom(src => src.EMail))
                .ForMember(a => a.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(a => a.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(a => a.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin));

            CreateMap<UserDto, User>()
                .ForMember(a => a.EMail, opt => opt.MapFrom(src => src.EMail))
                .ForMember(a => a.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(a => a.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(a => a.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
