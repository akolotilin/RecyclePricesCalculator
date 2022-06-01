using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Partners.UpdatePartner
{
    internal sealed class UpdatePartnerCommandHandler : IRequestHandler<UpdatePartnerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Partner> _partnerRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdatePartnerCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Partner> partnerRepository, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Unit> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository
                .Query()
                .Include(a => a.GoodsToSell)
                .Include(a => a.Factories)
                .FirstOrDefaultAsync(a => a.Id == request.PartnerId, cancellationToken);

            _mapper.Map(request.Partner, partner);

            _partnerRepository.Update(partner);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
