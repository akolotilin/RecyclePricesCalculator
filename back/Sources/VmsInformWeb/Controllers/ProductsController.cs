using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Products.AddProduct;
using VmsInform.Business.Commands.Products.AddProductGroup;
using VmsInform.Business.Commands.Products.UpdateProduct;
using VmsInform.Business.Queries.Products.GetProductById;
using VmsInform.Business.Queries.Products.GetProductGroups;
using VmsInform.Business.Queries.Products.GetProducts;
using VmsInform.Web.Dto.Common;
using VmsInform.Web.Dto.Products;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public Task<ProductEditDto> AddProduct(AddProductCommand command, CancellationToken cancellationToken)
        {
            return _mediator.Send(command, cancellationToken);
        }

        [HttpPut("update")]
        public Task UpdateProduct(UpdateProductCommand command, CancellationToken cancellationToken)
            => _mediator.Send(command, cancellationToken);

        [HttpGet]
        public Task<PagedDataDto<ProductEditDto>> GetProducts([FromQuery] GetProductsQuery query, CancellationToken cancellationToken)
            => _mediator.Send(query, cancellationToken);

        [HttpGet("{Id}")]
        public Task<ProductEditDto> GetProductById([FromRoute] GetProductByIdQuery query, CancellationToken cancellationToken)
            => _mediator.Send(query, cancellationToken);

        [HttpPost("groups/add")]
        public Task<ProductGroupDto> AddProductGroup(AddProductGroupCommand command, CancellationToken cancellationToken)
            => _mediator.Send(command, cancellationToken);

        [HttpGet("groups")]
        public Task<ProductHierarchyResultDto> GetProductGroups([FromQuery] GetProductGroupsQuery query, CancellationToken cancellationToken)
            => _mediator.Send(query, cancellationToken);
    }
}
