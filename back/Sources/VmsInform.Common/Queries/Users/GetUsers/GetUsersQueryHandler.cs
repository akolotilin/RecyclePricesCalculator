using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Queries.Users.GetUsers
{
    internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVmsInformRepository<User> _usersRepository;

        public GetUsersQueryHandler(IMapper mapper, IVmsInformRepository<User> usersRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await _usersRepository.Query().ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(allUsers);
        }
    }
}
