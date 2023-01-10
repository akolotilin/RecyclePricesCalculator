using MediatR;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Commands.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public ProductEditDto Item { get; set; }
    }
}
