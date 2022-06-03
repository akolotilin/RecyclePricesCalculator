using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Goods.Hierarchy;

namespace VmsInform.Business.Queries.Goods.GetHiererchy
{
    internal sealed class GetHiererchyQueryHandler : IRequestHandler<GetHiererchyQuery, IEnumerable<GoodsTreeNodeDto>>
    {
        private readonly IVmsInformRepository<GoodGroup> _goodGroupsRepository;
        private readonly IMapper _mapper;

        public GetHiererchyQueryHandler(IVmsInformRepository<GoodGroup> goodGroupsRepository, IMapper mapper)
        {
            _goodGroupsRepository = goodGroupsRepository ?? throw new ArgumentNullException(nameof(goodGroupsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        } 

        public async Task<IEnumerable<GoodsTreeNodeDto>> Handle(GetHiererchyQuery request, CancellationToken cancellationToken)
        {
            var allGroups = await _goodGroupsRepository.Query()
                .Include(a => a.Goods)
                .ToListAsync();

            return FillGroup(null, allGroups);
        }

        private IEnumerable<GoodsTreeNodeDto> FillGroup(GoodGroup parent, IEnumerable<GoodGroup> allGroups)
        {
            var result = new List<GoodsTreeNodeDto>();
            
            result.AddRange(allGroups
                .Where(a => a.ParentId == parent?.Id)
                .Select(group => new GoodsTreeNodeGroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Childs = FillGroup(group, allGroups)
            }));

            if (parent != null)
            {
                result.AddRange(parent.Goods.Select(a => _mapper.Map<GoodsTreeNodeItemDto>(a)));
            }

            return result;
        }
    }
}
