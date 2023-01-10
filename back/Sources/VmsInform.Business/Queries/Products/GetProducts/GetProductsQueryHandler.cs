using AutoMapper;
using System.Linq;
using VmsInform.Business.Queries.Common;
using VmsInform.DAL;
using VmsInform.DAL.Domain.Products;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Queries.Products.GetProducts
{
    internal sealed class GetProductsQueryHandler : CommonPagedDataQueryHandler<GetProductsQuery, ProductEditDto, ProductEntry>
    {
        public GetProductsQueryHandler(IVmsInformRepository<ProductEntry> repository, IMapper mapper)
            : base(repository, mapper)
        {

        }

        protected override IQueryable<ProductEntry> ApplyFilter(IQueryable<ProductEntry> source, GetProductsQuery request)
        {
            return source.Where(a => a.GroupId == request.ParentId);
        }
    }
}
