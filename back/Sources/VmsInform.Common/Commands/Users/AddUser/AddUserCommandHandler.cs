using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Commands.Users.AddUser
{
    internal sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserDto>
    {
        private readonly IVmsInformRepository<User> _usersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<User> usersRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User();
            _mapper.Map<UserDto, User>(request, newUser);
            await _usersRepository.AddAsync(newUser, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return _mapper.Map<UserDto>(newUser);
        }
    }
}
