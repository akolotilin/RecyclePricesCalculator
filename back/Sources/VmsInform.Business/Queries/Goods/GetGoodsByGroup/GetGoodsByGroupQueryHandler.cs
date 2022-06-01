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
using VmsInform.Web.Dto.Common;

namespace VmsInform.Business.Queries.Goods.GetGoodsByGroup
{
    internal sealed class GetGoodsByGroupQueryHandler : IRequestHandler<GetGoodsByGroupQuery, IEnumerable<NamedObjectDto>>
    {
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IMapper _mapper;

        public GetGoodsByGroupQueryHandler(IVmsInformRepository<Good> goodsRepository, IMapper mapper)
        {
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<NamedObjectDto>> Handle(GetGoodsByGroupQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<NamedObjectDto>>(await _goodsRepository.Query()
                 .Where(a => a.GoodGroupId == request.GroupId)
                 .Where(a => a.BaseGoodRuleId == null)
                 .ToListAsync(cancellationToken));
        }
    }
}
