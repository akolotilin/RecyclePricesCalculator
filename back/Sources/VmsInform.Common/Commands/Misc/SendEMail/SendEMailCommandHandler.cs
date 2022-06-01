using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace VmsInform.Common.Commands.Misc.SendEMail
{
    internal sealed class SendEMailCommandHandler : IRequestHandler<SendEMailCommand>
    {
        private readonly NetworkCredential _smtpCredentials;
        private readonly string _emailSendAccount;
        private readonly string _emailSendSmtpServer;

        public SendEMailCommandHandler()
        {
            _emailSendAccount = "vmsinform@vms34.ru";
            _emailSendSmtpServer = "smtp.yandex.ru";

            var credential = "vmsinform@vms34.ru;st3b8aXd";

            int dividorIndex = credential.IndexOf(';');
            if (dividorIndex < 0)
            {
                throw new InvalidDataException("Config parameter EmailSendCredentials should contails login and passord divided by ';'");
            }

            var credLogin = credential.Substring(0, dividorIndex);
            var credPassword = credential.Substring(dividorIndex + 1);

            _smtpCredentials = new NetworkCredential(credLogin, credPassword);
        }

        public async Task<Unit> Handle(SendEMailCommand request, CancellationToken cancellationToken)
        {
            await SendMessage(request.Subject, request.EMail, request.Body);
            return Unit.Value;
        }

        public async Task SendMessage(string subject, string to, string body, IEnumerable<KeyValuePair<string, Stream>> attachments = null)
        {
            using (var msg = new MailMessage(_emailSendAccount, to, subject, body))
            {
                if (attachments != null)
                {
                    foreach (var a in attachments)
                    {
                        msg.Attachments.Add(new Attachment(a.Value, a.Key));
                    }
                }

                bool needSend = true;
                while (needSend)
                {
                    using (var client = new SmtpClient(_emailSendSmtpServer, 25))
                    {
                        client.Credentials = _smtpCredentials;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.EnableSsl = true;

                        try
                        {
                            await client.SendMailAsync(msg);
                            needSend = false;
                        }
                        catch (Exception ex)
                        {
                            //mLogger.Error(ex);
                            //mLogger.Trace("Retry after 10s");
                            System.Threading.Thread.Sleep(5000);
                        }
                    }
                }
            }
        }

    }
}
