using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Partners.AddPartner
{
    internal sealed class AddPartnerCommandHandler : IRequestHandler<AddPartnerCommand>
    {
        private readonly IMapper _mapper;
        private readonly IVmsInformRepository<Partner> _partnerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPartnerCommandHandler(IMapper mapper, IVmsInformRepository<Partner> partnerRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(AddPartnerCommand request, CancellationToken cancellationToken)
        {
            var partner = _mapper.Map<Partner>(request);

            await _partnerRepository.AddAsync(partner, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
