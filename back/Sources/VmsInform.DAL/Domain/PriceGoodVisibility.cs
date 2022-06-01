using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class PriceGoodVisibility : VmsInformEntity
    {
        public long GoodId { get; set; }
        public virtual Good Good { get; set; }
        public bool IsVisible { get; set; }
    }
}
