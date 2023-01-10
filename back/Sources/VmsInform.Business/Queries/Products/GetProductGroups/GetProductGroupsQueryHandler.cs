using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain.Products;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Queries.Products.GetProductGroups
{
    internal sealed class GetProductGroupsQueryHandler : IRequestHandler<GetProductGroupsQuery, ProductHierarchyResultDto>
    {
        private readonly IRepositoryQuery<ProductGroupEntry> _productGroupsRepository;

        public GetProductGroupsQueryHandler(IRepositoryQuery<ProductGroupEntry> productGroupsRepository)
        {
            _productGroupsRepository = productGroupsRepository;
        }

        public async Task<ProductHierarchyResultDto> Handle(GetProductGroupsQuery request, CancellationToken cancellationToken)
        {
            var allItems = await _productGroupsRepository.Query()
                .ToListAsync(cancellationToken);

            return new ProductHierarchyResultDto
            {
                Groups = GetSubItems(request.ParentId, allItems),
                BreadCrumbs = GetBreadCrumpbs(request.ParentId, allItems)
            };
        }

        private IEnumerable<BreadCrumpbItemDto> GetBreadCrumpbs(long? parentId, IEnumerable<ProductGroupEntry> allGroups)
        {
            var current = allGroups.FirstOrDefault(a => a.Id == parentId);

            if (current == null)
            {
                return Enumerable.Empty<BreadCrumpbItemDto>()
                    .Append(new BreadCrumpbItemDto
                    {
                        Id = null,
                        Name = "Каталог"
                    });
            }

            return GetBreadCrumpbs(current.ParentId, allGroups)
                .Append(new BreadCrumpbItemDto
                {
                    Id = current.Id,
                    Name = current.Name
                });
        }

        private IEnumerable<ProductGroupHierarchyDto> GetSubItems(long? parentId, IEnumerable<ProductGroupEntry> allGroups)
        {
            var groupItems = allGroups.Where(a => a.ParentId == parentId);

            return groupItems.Select(a => new ProductGroupHierarchyDto
            {
                Id = a.Id,
                Name = a.Name,
                Childs = GetSubItems(a.Id, allGroups)
            }); ;
        }
    }
}
