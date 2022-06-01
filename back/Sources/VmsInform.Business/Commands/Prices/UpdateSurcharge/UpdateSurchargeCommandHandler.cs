using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Commands.Prices.UpdateSurcharge
{
    internal sealed class UpdateSurchargeCommandHandler : IRequestHandler<UpdateSurchargeCommand, PriceItemData>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVmsInformRepository<GoodSurcharge> _goodSurchargeRepository;

        public UpdateSurchargeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IVmsInformRepository<GoodSurcharge> goodSurchargeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _goodSurchargeRepository = goodSurchargeRepository ?? throw new ArgumentNullException(nameof(goodSurchargeRepository));
        }

        public async Task<PriceItemData> Handle(UpdateSurchargeCommand request, CancellationToken cancellationToken)
        {
            var surcharge = await _goodSurchargeRepository.Query()
                .Where(a => a.GoodId == request.GoodId && a.PriceTypeId == request.PriceId)
                .FirstOrDefaultAsync();

            if (surcharge == null)
            {
                surcharge = new GoodSurcharge
                {
                    GoodId = request.GoodId,
                    PriceTypeId = request.PriceId,
                    Surcharge = request.Surcharge
                };
                await _goodSurchargeRepository.AddAsync(surcharge, cancellationToken);
            }
            else
            {
                surcharge.Surcharge = request.Surcharge;
                _goodSurchargeRepository.Update(surcharge);
            }

            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<PriceItemData>(await _goodSurchargeRepository.Query()
                .Include(a => a.Good)
                .ThenInclude(a => a.BasePrice)
                .Include(a => a.PriceType)
                .FirstOrDefaultAsync(a => a.Id == surcharge.Id, cancellationToken));
        }
    }
}
