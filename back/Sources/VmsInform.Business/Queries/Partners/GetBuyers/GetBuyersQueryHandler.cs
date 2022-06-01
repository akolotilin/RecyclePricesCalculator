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
using VmsInform.Web.Dto.Common;

namespace VmsInform.Business.Queries.Partners.GetBuyers
{
    internal sealed class GetBuyersQueryHandler : IRequestHandler<GetBuyersQuery, IEnumerable<NamedObjectDto>>
    {
        private readonly IVmsInformRepository<Partner> _partnersRepository;
        private readonly IMapper _mapper;

        public GetBuyersQueryHandler(IVmsInformRepository<Partner> partnersRepository, IMapper mapper)
        {
            _partnersRepository = partnersRepository ?? throw new ArgumentNullException(nameof(partnersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<NamedObjectDto>> Handle(GetBuyersQuery request, CancellationToken cancellationToken)
        {
            var partners = await _partnersRepository.Query()
                .Where(a=>a.IsBuyer)
                .ToListAsync(cancellationToken);

            return _mapper.Map<NamedObjectDto[]>(partners);
        }
    }
}
