using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Goods;

namespace VmsInform.Business.Queries.Goods
{
    class GetGoodQueryHandler : IRequestHandler<GetGoodQuery, GoodEditDto>
    {
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IMapper _mapper;

        public GetGoodQueryHandler(IVmsInformRepository<Good> goodsRepository, IMapper mapper)
        {
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GoodEditDto> Handle(GetGoodQuery request, CancellationToken cancellationToken)
        {
            var good = await _goodsRepository.GetAsync(request.GoodId, cancellationToken);
            return _mapper.Map<GoodEditDto>(good);
        }
    }
}
