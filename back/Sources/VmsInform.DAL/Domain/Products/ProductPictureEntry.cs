using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain.Products
{
    public class ProductPictureEntry : VmsInformEntity
    {
        public long ProductId { get; set; }
        public virtual ProductEntry Product { get; set; }
        public long PictureId { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
