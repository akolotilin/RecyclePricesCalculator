using MediatR;

namespace VmsInform.Common.Commands.Users.ChangePassword
{
    public class ChangePasswordCommand : IRequest
    {
        public string NewPassword { get; set; }
        public long UserId { get; set; }
    }
}
