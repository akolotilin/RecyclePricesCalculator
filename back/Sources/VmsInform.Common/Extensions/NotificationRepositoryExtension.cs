using System.Linq;
using VmsInform.DAL;
using VmsInform.DAL.Domain.UserNotifications;

namespace VmsInform.Common.Extensions
{
    public static class NotificationRepositoryExtension
    {
        public static IQueryable<UserNotification> GetNotifications(this IVmsInformRepository<UserNotification> notificationRepository, long userId)
        {
            return notificationRepository.Query()
            .Where(a => a.UserId == userId)
                .Where(a => !a.IsRead);
        }
    }
}
