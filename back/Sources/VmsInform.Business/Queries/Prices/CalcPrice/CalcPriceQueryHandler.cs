using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Queries.Prices.CalcPrice
{
    internal sealed class CalcPriceQueryHandler : IRequestHandler<CalcPriceQuery, PriceDto>
    {
        private readonly IPricesService _pricesService;
        private readonly IVmsInformRepository<PriceType> _priceTypeRepository;

        public CalcPriceQueryHandler(IPricesService pricesService, IVmsInformRepository<PriceType> priceTypeRepository)
        {
            _pricesService = pricesService ?? throw new ArgumentNullException(nameof(pricesService));
            _priceTypeRepository = priceTypeRepository ?? throw new ArgumentNullException(nameof(priceTypeRepository));
        }

        public async Task<PriceDto> Handle(CalcPriceQuery request, CancellationToken cancellationToken)
        {
            var priceType = await _priceTypeRepository.GetAsync(request.PriceTypeId, cancellationToken);
            return await _pricesService.CalcPrice(request.GoodId, request.Surcharge, priceType.IsTransit, cancellationToken);
        }
    }
}
