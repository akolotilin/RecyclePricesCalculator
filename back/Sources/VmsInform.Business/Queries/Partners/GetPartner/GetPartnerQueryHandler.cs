using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.GetPartner
{
    class GetPartnerQueryHandler : IRequestHandler<GetPartnerQuery, EditPartnerDto>
    {
        private readonly IVmsInformRepository<Partner> _partnersRepository;
        private readonly IMapper _mapper;

        public GetPartnerQueryHandler(IVmsInformRepository<Partner> partnersRepository, IMapper mapper)
        {
            _partnersRepository = partnersRepository ?? throw new ArgumentNullException(nameof(partnersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<EditPartnerDto> Handle(GetPartnerQuery request, CancellationToken cancellationToken)
        {
            var partner = await _partnersRepository.Query()
                .Include(a => a.Contacts)
                .FirstAsync(a=>a.Id == request.Id, cancellationToken);

            return _mapper.Map<EditPartnerDto>(partner);
        }
    }
}
