using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Queries.Users.GetUsers
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
