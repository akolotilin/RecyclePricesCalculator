using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Common;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Queries.Prices.GetPrices
{
    internal sealed class GetPricesQueryHandler : IRequestHandler<GetPricesQuery, GetPricesResultDto>
    {
        private readonly IVmsInformRepository<PriceType> _priceTypesRepository;
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IVmsInformRepository<GoodGroup> _goodGroupsRepository;
        private readonly IVmsInformRepository<PriceGoodOrder> _priceGoodOrderRepository;
        private readonly IPricesService _pricesService;
        private readonly IMapper _mapper;

        public GetPricesQueryHandler(IVmsInformRepository<PriceType> priceTypesRepository, IVmsInformRepository<Good> goodsRepository,
            IVmsInformRepository<GoodGroup> goodGroupsRepository, IVmsInformRepository<PriceGoodOrder> priceGoodOrderRepository, 
            IPricesService pricesService, IMapper mapper)
        {
            _priceTypesRepository = priceTypesRepository ?? throw new ArgumentNullException(nameof(priceTypesRepository));
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _goodGroupsRepository = goodGroupsRepository ?? throw new ArgumentNullException(nameof(goodGroupsRepository));
            _priceGoodOrderRepository = priceGoodOrderRepository ?? throw new ArgumentNullException(nameof(priceGoodOrderRepository));
            _pricesService = pricesService ?? throw new ArgumentNullException(nameof(pricesService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetPricesResultDto> Handle(GetPricesQuery request, CancellationToken cancellationToken)
        {
            var goodOrder = await _priceGoodOrderRepository.Query().ToListAsync();

            var priceTypes = await _priceTypesRepository.Query()
                .Select(a => _mapper.Map<PriceTypeDto>(a))
                .ToListAsync();

            await _pricesService.PreloadData();

            var goods = await _goodsRepository.Query()
                .Include(a => a.GoodSurcharges)
                .Include(a => a.BasePrice)
                .ThenInclude(a => a.Partner)
                .ToListAsync();

            var groupedGoods = goods.GroupBy(a => a.GoodGroupId)
                .ToList();

            var flatGoods = new List<PricesEditGoodDto>();

            var groups = await _goodGroupsRepository.Query()
                .Where(a => a.Parent != null)
                .ToListAsync();

            foreach(var group in groups)
            {
                flatGoods.Add(new PricesEditGoodDto { IsGroup = true, Name = group.Name, Id = group.Id });

                var data = from gg in groupedGoods
                           where gg.Key == @group.Id
                           from good in gg
                           join order in goodOrder on good.Id equals order.GoodId into joinedOrder
                           from jo in joinedOrder.DefaultIfEmpty()
                           select new { Order = jo?.Order ?? 0, Good = good } into goodsWithOrder
                           orderby goodsWithOrder.Order
                           select _mapper.Map<PricesEditGoodDto>(goodsWithOrder.Good);

                flatGoods.AddRange(data);
            }

            return new GetPricesResultDto
            {
                PriceTypes = priceTypes,
                Goods = flatGoods
            };
        }
    }
}
