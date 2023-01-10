using System.Collections.Generic;

namespace VmsInform.Web.Dto.Products
{
    public class ProductEditDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductComponentDto> Components { get; set; }
        public IEnumerable<long> Pictures { get; set; }
    }
}
