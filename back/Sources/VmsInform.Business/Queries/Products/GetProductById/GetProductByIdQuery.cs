using MediatR;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Queries.Products.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductEditDto>
    {
        public long Id { get; set; }
    }
}
