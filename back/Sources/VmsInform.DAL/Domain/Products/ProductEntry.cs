using System.Collections.Generic;

namespace VmsInform.DAL.Domain.Products
{
    public class ProductEntry : NamedObject
    {
        public string Description { get; set; }
        public virtual ICollection<ProductComponentRawEntry> ComponentsRaw { get; set; }
        public virtual ICollection<ProductPictureEntry> Pictures { get; set; }
        public long? GroupId { get; set; }
        public virtual ProductGroupEntry Group { get; set; }
    }
}
