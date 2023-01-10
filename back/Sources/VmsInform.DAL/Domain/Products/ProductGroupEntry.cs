using System.Collections.Generic;

namespace VmsInform.DAL.Domain.Products
{
    public class ProductGroupEntry : NamedObject
    {
        public long? ParentId { get; set; }
        public virtual ProductGroupEntry Parent { get; set; }
        public virtual IEnumerable<ProductEntry> Products { get; set; }
    }
}
