using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Extensions;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Commands.Users.AuthUser
{
    internal sealed class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, UserSessionAuthDto>
    {
        private readonly IVmsInformRepository<User> _usersRepository;
        private readonly IVmsInformRepository<UserSession> _userSessionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;

        public AuthUserCommandHandler(IVmsInformRepository<User> usersRepository, IVmsInformRepository<UserSession> userSessionRepository, 
            IUnitOfWork unitOfWork, IDateTimeService dateTimeService, IMapper mapper)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _userSessionRepository = userSessionRepository ?? throw new ArgumentNullException(nameof(userSessionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserSessionAuthDto> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = request.Password.ToMd5();

            var userEntry = await _usersRepository.Query()
                .FirstOrDefaultAsync(a => a.IsActive && a.EMail == request.EMail && a.PasswordHash == passwordHash);

            if (userEntry == null)
                return null;

            var session = new UserSession
            {
                SessionKey = Guid.NewGuid().ToString(),
                StartTime = _dateTimeService.Now,
                UserId = userEntry.Id
            };

            await _userSessionRepository.AddAsync(session, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<UserSessionAuthDto>(session);
        }
    }
}
