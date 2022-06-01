using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Partners.DeletePartnerOffer
{
    internal sealed class DeletePartnerOfferCommandHandler : IRequestHandler<DeletePartnerOfferCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<PartnerGoodsToSell> _offersRepository;

        public DeletePartnerOfferCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<PartnerGoodsToSell> offersRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _offersRepository = offersRepository ?? throw new ArgumentNullException(nameof(offersRepository));
        }

        public async Task<Unit> Handle(DeletePartnerOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = await _offersRepository.Query()
                .Where(a => a.PartnerId == request.PartnerId && a.GoodId == request.GoodId && a.FactoryId == request.FactoryId)
                .FirstOrDefaultAsync(cancellationToken);

            if (offer != null)
            {
                _offersRepository.Delete(offer);
                await _unitOfWork.SaveAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
