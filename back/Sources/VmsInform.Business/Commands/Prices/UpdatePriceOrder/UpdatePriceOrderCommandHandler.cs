using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Prices.UpdatePriceOrder
{
    internal class UpdatePriceOrderCommandHandler : IRequestHandler<UpdatePriceOrderCommand>
    {
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IVmsInformRepository<PriceGoodOrder> _priceGoodOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePriceOrderCommandHandler(IVmsInformRepository<Good> goodsRepository, IVmsInformRepository<PriceGoodOrder> priceGoodOrderRepository,
            IUnitOfWork unitOfWork)
        {
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _priceGoodOrderRepository = priceGoodOrderRepository ?? throw new ArgumentNullException(nameof(priceGoodOrderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(UpdatePriceOrderCommand request, CancellationToken cancellationToken)
        {
            var good = await _goodsRepository.GetAsync(request.GoodId, cancellationToken);

            var allGoodsFromSameGroup = await _goodsRepository.Query()
                .Where(a => a.GoodGroupId == good.GoodGroupId)
                .ToListAsync(cancellationToken);

            var goodOrder = await _priceGoodOrderRepository.Query().ToListAsync();

            var sortedGoods = (from gg in allGoodsFromSameGroup
                       join order in goodOrder on gg.Id equals order.GoodId into joinedOrder
                       from jo in joinedOrder.DefaultIfEmpty()
                       select new { Order = jo?.Order ?? 0, Good = gg } into goodsWithOrder
                       orderby goodsWithOrder.Order
                       select goodsWithOrder.Good).ToList();

            sortedGoods.Remove(good);

            var indexToInsert = request.MoveAfterGoodId.HasValue ? sortedGoods.FindIndex(a => a.Id == request.MoveAfterGoodId.Value) + 1 : 0;
            sortedGoods.Insert(indexToInsert, good);

            int index = 0;

            var indexedGoods = sortedGoods.Select(a => new { Index = index++, Good = a });

            foreach (var goodIndex in indexedGoods)
            {
                var existingOrder = goodOrder.FirstOrDefault(a => a.GoodId == goodIndex.Good.Id);
                if (existingOrder != null)
                {
                    existingOrder.Order = goodIndex.Index;
                    _priceGoodOrderRepository.Update(existingOrder);
                }
                else
                {
                    var newOrder = new PriceGoodOrder { GoodId = goodIndex.Good.Id, Order = goodIndex.Index };
                    await _priceGoodOrderRepository.AddAsync(newOrder, cancellationToken);
                }
            }

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
