using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Commands.Users.ChangePassword;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Common.Commands.ChangePasswordByRequest
{
    internal sealed class ChangePasswordByRequestCommandHandler : IRequestHandler<ChangePasswordByRequestCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<PasswordRestoreRequest> _requestRepository;
        private readonly IDateTimeService _dateTimeService;
        private readonly ITransaction _transaction;

        public ChangePasswordByRequestCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IVmsInformRepository<PasswordRestoreRequest> requestRepository,
            IDateTimeService dateTimeService, ITransaction transaction)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _requestRepository = requestRepository ?? throw new ArgumentNullException(nameof(requestRepository));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        public async Task<Unit> Handle(ChangePasswordByRequestCommand request, CancellationToken cancellationToken)
        {
            var changePasswordRequest = await _requestRepository.Query()
                .FirstOrDefaultAsync(a => a.Key == request.RequestKey && !a.IsClosed && a.ExpiryDate > _dateTimeService.Now);

            if (changePasswordRequest == null)
            {
                throw new InvalidOperationException("Invalid request");
            }

            var transaction = await _transaction.BeginAsync(cancellationToken);
            try
            {
                await _mediator.Send(new ChangePasswordCommand { UserId = changePasswordRequest.UserId, NewPassword = request.NewPassword }, cancellationToken);

                changePasswordRequest.IsClosed = true;

                _requestRepository.Update(changePasswordRequest);
                await _unitOfWork.SaveAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }

            return Unit.Value;
        }
    }
}
