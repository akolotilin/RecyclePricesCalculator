using MediatR;

namespace VmsInform.Common.Commands.ChangePasswordByRequest
{
    public class ChangePasswordByRequestCommand : IRequest
    {
        public string RequestKey { get; set; }
        public string NewPassword { get; set; }
    }
}
