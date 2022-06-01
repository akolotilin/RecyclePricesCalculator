using AutoMapper;
using System;
using VmsInform.DAL.Domain.UserNotifications;
using VmsInform.Web.Dto.Notifications;

namespace VmsInform.Common.TypeMapping.Profiles
{
    internal sealed class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<UserNotification, UserNotificationDto>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.Title, opt => opt.MapFrom(src => src.Subject))
                .ForMember(a => a.IsImportant, opt => opt.MapFrom(src => src.IsImportant))
                .ForMember(a => a.DateTime, opt => opt.MapFrom(src => src.DateTime))
                .ForMember(a => a.NotificationType, opt => opt.MapFrom(src => MapType(src)))
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        private static string MapType(UserNotification notification)
        {
            switch(notification)
            {
                case UserNotificationNews news:
                    return "news";
                default:
                    throw new InvalidOperationException("Unknown notification type");
            }
        }
    }
}
