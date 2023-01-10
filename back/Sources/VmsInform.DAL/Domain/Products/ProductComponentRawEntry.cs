using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain.Products
{
    public class ProductComponentRawEntry : VmsInformEntity
    {
        public long ProductId { get; set; }
        public virtual ProductEntry Product { get; set; }
        public long GoodId { get; set; }
        public virtual Good Good { get; set; }
        public decimal Percentage { get; set; }
    }
}
