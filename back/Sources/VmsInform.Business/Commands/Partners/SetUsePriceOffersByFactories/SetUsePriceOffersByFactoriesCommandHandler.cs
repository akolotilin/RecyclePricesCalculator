using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Partners.SetUsePriceOffersByFactories
{
    public class SetUsePriceOffersByFactoriesCommandHandler : IRequestHandler<SetUsePriceOffersByFactoriesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Partner> _partnerRepository;

        public SetUsePriceOffersByFactoriesCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Partner> partnerRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
        }

        public async Task<Unit> Handle(SetUsePriceOffersByFactoriesCommand request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.Query()
                .FirstOrDefaultAsync(a => a.Id == request.PartnerId, cancellationToken);

            if (partner == null)
                throw new NotFoundException("Partner not found");

            partner.UsePriceOffersByFactories = request.UsePriceOffersByFactories;
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
