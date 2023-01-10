using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Commands.Products.AddProduct
{
    public class AddProductCommand : IRequest<ProductEditDto>
    {
        public ProductEditDto Item { get; set; }
    }
}
