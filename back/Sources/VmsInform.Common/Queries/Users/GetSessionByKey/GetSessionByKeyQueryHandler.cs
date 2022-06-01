using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Queries.Users.GetSessionByKey
{
    internal class GetSessionByKeyQueryHandler : IRequestHandler<GetSessionByKeyQuery, UserSessionDto>
    {
        private readonly IVmsInformRepository<UserSession> _sessionRepository;
        private readonly IMapper _mapper;

        public GetSessionByKeyQueryHandler(IVmsInformRepository<UserSession> sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserSessionDto> Handle(GetSessionByKeyQuery request, CancellationToken cancellationToken)
        {
            var session = await _sessionRepository.Query()
                .Where(a => a.SessionKey == request.Key)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<UserSessionDto>(session);
        }
    }
}
