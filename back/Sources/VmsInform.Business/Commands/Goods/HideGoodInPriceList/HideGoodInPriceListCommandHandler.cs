using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Goods.HideGoodInPriceList
{
    internal sealed class HideGoodInPriceListCommandHandler : IRequestHandler<HideGoodInPriceListCommand>
    {
        private readonly IVmsInformRepository<PriceGoodVisibility> _goodVisibilityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HideGoodInPriceListCommandHandler(IVmsInformRepository<PriceGoodVisibility> goodVisibilityRepository, IUnitOfWork unitOfWork)
        {;
            _goodVisibilityRepository = goodVisibilityRepository ?? throw new ArgumentNullException(nameof(goodVisibilityRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(HideGoodInPriceListCommand request, CancellationToken cancellationToken)
        {
            var goodVisibility = await _goodVisibilityRepository.Query()
                .FirstOrDefaultAsync(a => a.GoodId == request.GoodId, cancellationToken);
            
            if (goodVisibility != null)
            {
                goodVisibility.IsVisible = false;
            }
            else
            {
                goodVisibility = new PriceGoodVisibility
                {
                    GoodId = request.GoodId,
                    IsVisible = false
                };
                await _goodVisibilityRepository.AddAsync(goodVisibility, cancellationToken);
            }

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
