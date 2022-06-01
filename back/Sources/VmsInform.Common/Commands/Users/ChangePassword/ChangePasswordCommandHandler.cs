using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Extensions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Common.Commands.Users.ChangePassword
{
    internal sealed class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<User> _usersRepository;

        public ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<User> usersRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetAsync(request.UserId, cancellationToken);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid user id");
            }

            user.PasswordHash = request.NewPassword.ToMd5();
            _usersRepository.Update(user);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
