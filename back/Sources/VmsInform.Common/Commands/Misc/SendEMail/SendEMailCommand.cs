using MediatR;

namespace VmsInform.Common.Commands.Misc.SendEMail
{
    public class SendEMailCommand : IRequest
    {
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
