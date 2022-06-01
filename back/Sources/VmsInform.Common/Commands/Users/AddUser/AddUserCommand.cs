using MediatR;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Commands.Users.AddUser
{
    public class AddUserCommand : UserDto, IRequest<UserDto>
    {
    }
}
