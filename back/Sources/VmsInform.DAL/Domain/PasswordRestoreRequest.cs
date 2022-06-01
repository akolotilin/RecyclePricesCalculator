using System;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class PasswordRestoreRequest : VmsInformEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiryDate {get;set;}
        public string Key { get; set; }
        public bool IsClosed { get; set; }
    }
}
