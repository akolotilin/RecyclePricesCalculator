using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Commands.Users.UpdateUser
{
    internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IVmsInformRepository<User> _usersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IVmsInformRepository<User> usersRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetAsync(request.User.Id, cancellationToken);

            _mapper.Map(request.User, user);

            _usersRepository.Update(user);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<UserDto>(user);
        }
    }
}
