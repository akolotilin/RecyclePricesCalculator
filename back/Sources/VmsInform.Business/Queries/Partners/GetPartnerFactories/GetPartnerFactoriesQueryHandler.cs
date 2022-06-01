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

namespace VmsInform.Business.Queries.Partners.GetPartnerFactories
{
    internal sealed class GetPartnerFactoriesQueryHandler : IRequestHandler<GetPartnerFactoriesQuery, IEnumerable<PartnerFactoryDto>>
    {
        private readonly IVmsInformRepository<PartnerFactory> _factoryRepository;
        private readonly IMapper _mapper;

        public GetPartnerFactoriesQueryHandler(IVmsInformRepository<PartnerFactory> factoryRepository, IMapper mapper)
        {
            _factoryRepository = factoryRepository ?? throw new ArgumentNullException(nameof(factoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PartnerFactoryDto>> Handle(GetPartnerFactoriesQuery request, CancellationToken cancellationToken)
        {
            var addresses = _factoryRepository.Query()
                .Where(a => a.PartnerId == request.PartnerId);

            return await _mapper.ProjectTo<PartnerFactoryDto>(addresses)
                .ToListAsync(cancellationToken);
        }
    }
}
