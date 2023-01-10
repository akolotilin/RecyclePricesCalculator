using MediatR;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Commands.Products.AddProductGroup
{
    /// <summary>
    /// Add new product group
    /// </summary>
    public class AddProductGroupCommand : IRequest<ProductGroupDto>
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
