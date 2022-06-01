using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Queries.Users
{
    internal sealed class CheckPasswordChangeRequestQueryHandler : IRequestHandler<CheckPasswordChangeRequestQuery, CheckPasswordChangeRequestResultDto>
    {
        private readonly IVmsInformRepository<PasswordRestoreRequest> _requestsRepository;
        private readonly IDateTimeService _dateTimeService;

        private static CheckPasswordChangeRequestResultDto _failResult = new CheckPasswordChangeRequestResultDto { IsOk = false };

        public CheckPasswordChangeRequestQueryHandler(IVmsInformRepository<PasswordRestoreRequest> requestsRepository, IDateTimeService dateTimeService)
        {
            _requestsRepository = requestsRepository ?? throw new ArgumentNullException(nameof(requestsRepository));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public async Task<CheckPasswordChangeRequestResultDto> Handle(CheckPasswordChangeRequestQuery request, CancellationToken cancellationToken)
        {
            var requestEntry = await _requestsRepository.Query().FirstOrDefaultAsync(a => a.Key == request.Key && !a.IsClosed, cancellationToken);

            if (requestEntry == null)
                return _failResult;

            if (requestEntry.ExpiryDate < _dateTimeService.Now)
                return _failResult;

            return new CheckPasswordChangeRequestResultDto
            {
                IsOk = true,
                UserName = requestEntry.User.FullName
            };
        }
    }
}
