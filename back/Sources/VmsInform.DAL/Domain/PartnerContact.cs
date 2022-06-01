using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public enum ContactType
    {
        CellPhone,
        WorkPhone,
        Skype,
        Email,
        WhatsApp,
        Viber,
        Telegram
    }

    public class PartnerContact : VmsInformEntity
    {
        public virtual ContactType ContactType { get; set; }
        public virtual Partner Partner { get; set; }
        public long PartnerId { get; set; }
        public string ContactData { get; set; }
    }
}
