using System.Collections.Generic;

namespace VmsInform.Web.Dto.Products
{
    public class ProductGroupHierarchyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductGroupHierarchyDto> Childs { get; set; }
    }
}
