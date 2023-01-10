using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Products
{
    public class ProductGroupDto : NamedObjectDto
    {
        public long? ParentId { get; set; }
    }
}
