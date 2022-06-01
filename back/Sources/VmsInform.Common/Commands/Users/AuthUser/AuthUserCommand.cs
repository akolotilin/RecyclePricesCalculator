using MediatR;
using VmsInform.Web.Dto.Users;

namespace VmsInform.Common.Commands.Users.AuthUser
{
    public class AuthUserCommand : IRequest<UserSessionAuthDto>
    {
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
