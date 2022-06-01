using AutoMapper;
using System;
using VmsInform.Common.Services;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.News;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal sealed class NewsProfile : Profile
    {
        public NewsProfile(Func<IUserService> userServiceFactory)
        {
            CreateMap<NewsEntry, NewsEditDto>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(a => a.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(a => a.IsImportant, opt => opt.MapFrom(src => src.IsImportant))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<NewsEditDto, NewsEntry>()
                .ForMember(a => a.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(a => a.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(a => a.IsImportant, opt => opt.MapFrom(src => src.IsImportant))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<NewsEntry, NewsDto>()
                .ForMember(a => a.Author, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(a => a.IsPublished, opt => opt.MapFrom(src => src.IsPublished))
                .ForMember(a => a.IsUserAuthor, opt => opt.MapFrom(src => IsUserAuthor(src.AuthorId, userServiceFactory().CurrentUser)));
        }

        private static bool IsUserAuthor(long newsUserId, UserDto currentUser)
        {
            return currentUser?.Id == newsUserId;
        }
    }
}
