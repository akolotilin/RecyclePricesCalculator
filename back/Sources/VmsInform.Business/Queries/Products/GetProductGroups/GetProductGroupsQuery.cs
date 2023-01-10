using MediatR;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Queries.Products.GetProductGroups
{
    public class GetProductGroupsQuery : IRequest<ProductHierarchyResultDto>
    {
        public long? ParentId { get; set; }
    }
}
