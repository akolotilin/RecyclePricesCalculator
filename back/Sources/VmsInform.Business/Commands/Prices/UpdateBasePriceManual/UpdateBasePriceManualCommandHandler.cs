using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Commands.Prices.UpdateBasePriceManual
{
    internal sealed class UpdateBasePriceManualCommandHandler : IRequestHandler<UpdateBasePriceManualCommand, PricesEditGoodDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<BaseGoodPrice> _baseGoodPriceRepository;
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IMapper _mapper;   

        public UpdateBasePriceManualCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<BaseGoodPrice> baseGoodPriceRepository,
            IVmsInformRepository<Good> goodsRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _baseGoodPriceRepository = baseGoodPriceRepository ?? throw new ArgumentNullException(nameof(baseGoodPriceRepository));
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PricesEditGoodDto> Handle(UpdateBasePriceManualCommand request, CancellationToken cancellationToken)
        {
            var basePrice = await _baseGoodPriceRepository.Query()
                .FirstOrDefaultAsync(a => a.GoodId == request.GoodId);

            if (basePrice != null)
            {
                basePrice.Price = request.BasePrice;
                basePrice.PartnerId = null;
                basePrice.Partner = null;
                basePrice.ExpirationDate = DateTime.Parse(request.ValidThru);
                basePrice.LastUpdated = DateTime.Now;
                _baseGoodPriceRepository.Update(basePrice);
            }
            else
            {
                basePrice = new BaseGoodPrice
                {
                    GoodId = request.GoodId,
                    Price = request.BasePrice,
                    LastUpdated = DateTime.Now,
                    ExpirationDate = DateTime.Parse(request.ValidThru)
                };
                await _baseGoodPriceRepository.AddAsync(basePrice, cancellationToken);
            }

            await _unitOfWork.SaveAsync(cancellationToken);

            var good = await _goodsRepository.Query()
                .Include(a => a.GoodSurcharges)
                .Include(a => a.BasePrice)
                .ThenInclude(a => a.Partner)
                .FirstOrDefaultAsync(a => a.Id == request.GoodId);

            return _mapper.Map<PricesEditGoodDto>(good);
        }
    }
}
