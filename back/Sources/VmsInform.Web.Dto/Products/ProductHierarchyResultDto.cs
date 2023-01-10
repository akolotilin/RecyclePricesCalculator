using System.Collections.Generic;

namespace VmsInform.Web.Dto.Products
{
    public class ProductHierarchyResultDto
    {
        public IEnumerable<ProductGroupHierarchyDto> Groups { get; set; }
        public IEnumerable<BreadCrumpbItemDto> BreadCrumbs { get; set; }
    }
}
