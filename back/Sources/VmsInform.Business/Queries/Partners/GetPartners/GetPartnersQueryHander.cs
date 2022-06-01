using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.GetPartners
{
    internal sealed class GetPartnersQueryHander : IRequestHandler<GetPartnersQuery, IEnumerable<PartnerDto>>
    {
        private readonly IVmsInformRepository<Partner> _partnerRepository;
        private readonly IMapper _mapper;

        public GetPartnersQueryHander(IVmsInformRepository<Partner> partnerRepository, IMapper mapper)
        {
            _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PartnerDto>> Handle(GetPartnersQuery request, CancellationToken cancellationToken)
        {
            var partners = await _partnerRepository.Query()
                .Include(a => a.Contacts)
                .ToListAsync(cancellationToken);

            return partners.Select(a => _mapper.Map<PartnerDto>(a))
                .ToList();
        }
    }
}
