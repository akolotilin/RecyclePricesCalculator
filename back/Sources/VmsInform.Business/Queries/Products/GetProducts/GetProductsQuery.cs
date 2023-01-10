using VmsInform.Business.Queries.Common;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Queries.Products.GetProducts
{
    public class GetProductsQuery : IPagedDataQuery<ProductEditDto>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public long? ParentId { get; set; }
    }
}
