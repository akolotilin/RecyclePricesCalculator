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
using VmsInform.Web.Dto.Prices;

namespace VmsInform.Business.Queries.Prices.GetPriceList
{
    internal sealed class GetPriceListQueryHandler : IRequestHandler<GetPriceListQuery, IEnumerable<PriceListItemDto>>
    {
        private readonly IPricesService _priceService;
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IVmsInformRepository<PriceType> _priceTypesRepository;

        public GetPriceListQueryHandler(IPricesService priceService, IVmsInformRepository<Good> goodsRepository, IVmsInformRepository<PriceType> priceTypesRepository)
        {
            _priceService = priceService ?? throw new ArgumentNullException(nameof(priceService));
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _priceTypesRepository = priceTypesRepository ?? throw new ArgumentNullException(nameof(priceTypesRepository));
        }

        public async Task<IEnumerable<PriceListItemDto>> Handle(GetPriceListQuery request, CancellationToken cancellationToken)
        {
            await _priceService.PreloadData();
            var service = _priceService;
            var prices = await _goodsRepository.Query()
                .Include(a => a.GoodGroup)
                .Include(a => a.GoodSurcharges)
                .Select(a => new { Good = a, Surcharge = a.GoodSurcharges.FirstOrDefault(x => x.PriceTypeId == request.PriceId) })
                .Where(a => a.Surcharge != null)
                .ToListAsync(cancellationToken);

            return prices
                .Select(a => new PriceListItemDto(service.CalcPrice(a.Good.Id, a.Surcharge.Surcharge, a.Surcharge.PriceType.IsTransit, cancellationToken).Result) {
                    Name = a.Good.Name,
                    GroupName = a.Good.GoodGroup.Name
                })
                .ToList();
        }
    }
}
