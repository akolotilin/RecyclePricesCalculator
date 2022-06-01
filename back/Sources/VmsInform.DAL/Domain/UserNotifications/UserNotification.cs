using System;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain.UserNotifications
{
    public abstract class UserNotification : VmsInformEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DateTime { get; set; }
        public string Subject { get; set; }
        public bool IsRead { get; set; }
        public bool IsImportant { get; set; }
    }
}
