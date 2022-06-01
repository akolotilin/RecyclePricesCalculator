using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.AddPartnerFactory
{
    internal sealed class AddPartnerFactoryCommandHandler : IRequestHandler<AddPartnerFactoryCommand, PartnerFactoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Partner> _partnerRepository;
        private readonly IMapper _mapper;

        public AddPartnerFactoryCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Partner> partnerRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PartnerFactoryDto> Handle(AddPartnerFactoryCommand request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.Query()
                .Include(a => a.Factories)
                .FirstOrDefaultAsync(a => a.Id == request.PartnerId, cancellationToken);

            if (partner == null)
                throw new NotFoundException("Partner not found");

            var newPartnerFactory = new PartnerFactory { FactoryId = request.FactoryId };

            partner.Factories.Add(newPartnerFactory);

            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<PartnerFactoryDto>(newPartnerFactory);
        }
    }
}
