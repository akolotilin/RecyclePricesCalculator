using MediatR;

namespace VmsInform.Common.Commands.RestorePassword
{
    public class RestorePasswordCommand : IRequest
    {
        public string EMail { get; set; }
    }
}
