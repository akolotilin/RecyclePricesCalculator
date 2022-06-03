using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Commands.Misc.SendEMail;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Common.Commands.RestorePassword
{
    internal sealed class RestorePasswordCommandHandler : IRequestHandler<RestorePasswordCommand>
    {
        private readonly IVmsInformRepository<User> _usersRepository;
        private readonly IVmsInformRepository<PasswordRestoreRequest> _passwordRestoreRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMediator _mediator;

        public RestorePasswordCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<User> usersRepository, 
            IVmsInformRepository<PasswordRestoreRequest> passwordRestoreRepository, IDateTimeService dateTimeService, IMediator mediator)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _passwordRestoreRepository = passwordRestoreRepository ?? throw new ArgumentNullException(nameof(passwordRestoreRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Unit> Handle(RestorePasswordCommand request, CancellationToken cancellationToken)
        {
            bool isFirstUser = !await _usersRepository.Query().AnyAsync(cancellationToken);
            User user;
            if (isFirstUser)
            {
                user = new User {
                    EMail = request.EMail,
                    FullName = request.EMail,
                    IsAdmin = true,
                    IsActive = true,
                    PasswordHash = string.Empty
                };

                await _usersRepository.AddAsync(user, cancellationToken);
            }
            else
            {
                user = await _usersRepository
                    .Query()
                    .FirstOrDefaultAsync(a => a.EMail == request.EMail && a.IsActive);
            }

            if (user != null)
            {
                var passwordRequestEntry = await CreateRequest(user, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);

                var body = $"Ваша ссылка для восстановления пароля: http://localhost:4200/login/restore/{passwordRequestEntry.Key}";

                await _mediator.Send(new SendEMailCommand { EMail = user.EMail, Subject = "Восстановление пароля", Body = body }, cancellationToken);
            }

            return Unit.Value;
        }

        private async Task<PasswordRestoreRequest> CreateRequest(User user, CancellationToken cancellationToken)
        {
            var request = await _passwordRestoreRepository.Query()
                .FirstOrDefaultAsync(a => a.UserId == user.Id && !a.IsClosed && a.ExpiryDate < _dateTimeService.Now);

            if (request == null)
            {

                request = new PasswordRestoreRequest
                {
                    CreateDate = _dateTimeService.Now,
                    ExpiryDate = _dateTimeService.Now.AddDays(1),
                    IsClosed = false,
                    User = user,
                    Key = Guid.NewGuid().ToString()
                };

                await _passwordRestoreRepository.AddAsync(request, cancellationToken);
            }

            return request;
        }
        
    }
}
