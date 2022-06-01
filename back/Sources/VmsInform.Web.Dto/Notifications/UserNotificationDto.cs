using System;

namespace VmsInform.Web.Dto.Notifications
{
    public class UserNotificationDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Icon { get; set; }
        public bool IsImportant { get; set; }
        public string NotificationType { get; set; }
    }
}
