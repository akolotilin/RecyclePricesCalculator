using System;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class UserSession : VmsInformEntity
    {
        public DateTime StartTime { get; set; }
        public string SessionKey { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
