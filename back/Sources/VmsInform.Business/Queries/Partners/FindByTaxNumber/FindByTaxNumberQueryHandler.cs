using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.FindByTaxNumber
{
    internal class FindByTaxNumberQueryHandler : IRequestHandler<FindByTaxNumberQuery, PartnerDto>
    {
        private readonly IVmsInformRepository<Partner> _partnerRepository;
        private readonly IMapper _mapper;

        public FindByTaxNumberQueryHandler(IVmsInformRepository<Partner> partnerRepository, IMapper mapper)
        {
            _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PartnerDto> Handle(FindByTaxNumberQuery request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.Query()
                .FirstOrDefaultAsync(a => a.TaxNumber == request.TaxNumber, cancellationToken);

            return _mapper.Map<PartnerDto>(partner);
        }
    }
}
