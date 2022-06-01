using MediatR;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public UserDto User { get; set; }
    }
}
