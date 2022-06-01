using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Commands.Prices.UpdateBasePriceFromOffer
{
    internal sealed class UpdateBasePriceFromOfferCommandHandler : IRequestHandler<UpdateBasePriceFromOfferCommand, PricesEditGoodDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<BaseGoodPrice> _baseGoodPriceRepository;
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IVmsInformRepository<Currency> _currencyRepository;
        private readonly IMapper _mapper;

        public UpdateBasePriceFromOfferCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<BaseGoodPrice> baseGoodPriceRepository,
            IVmsInformRepository<Good> goodsRepository, IVmsInformRepository<Currency> currencyRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _baseGoodPriceRepository = baseGoodPriceRepository ?? throw new ArgumentNullException(nameof(baseGoodPriceRepository));
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PricesEditGoodDto> Handle(UpdateBasePriceFromOfferCommand request, CancellationToken cancellationToken)
        {
            var basePrice = await _baseGoodPriceRepository.Query()
                .FirstOrDefaultAsync(a => a.GoodId == request.GoodId);

            var currency = await _currencyRepository.Query()
                .FirstOrDefaultAsync(a => a.Code == request.Offer.Currency, cancellationToken);

            if (basePrice != null)
            {
                basePrice.Price = request.Offer.Price;
                basePrice.PartnerId = request.Offer.PartnerId;
                basePrice.FactoryId = request.Offer.FactoryId;
                basePrice.ExpirationDate = DateTime.Parse(request.Offer.ValidThru);
                basePrice.LastUpdated = DateTime.Now;
                basePrice.CurrencyId = currency.Id;
                _baseGoodPriceRepository.Update(basePrice);
            }
            else
            {
                basePrice = new BaseGoodPrice
                {
                    GoodId = request.GoodId,
                    PartnerId = request.Offer.PartnerId,
                    FactoryId = request.Offer.FactoryId,
                    Price = request.Offer.Price,
                    LastUpdated = DateTime.Now,
                    CurrencyId = currency.Id,
                    ExpirationDate = DateTime.Parse(request.Offer.ValidThru)
                };
                await _baseGoodPriceRepository.AddAsync(basePrice, cancellationToken);
            }

            await _unitOfWork.SaveAsync(cancellationToken);

            var good = await _goodsRepository.Query()
                .Include(a => a.GoodSurcharges)
                .Include(a => a.BasePrice)
                .ThenInclude(a => a.Partner)
                .Include(a => a.BasePrice.Factory)
                .FirstOrDefaultAsync(a => a.Id == request.GoodId);

            return _mapper.Map<PricesEditGoodDto>(good);
        }
    }
}
