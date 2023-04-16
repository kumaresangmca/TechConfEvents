using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using TechConf.Common.Options;
using TechConf.Models.DTO;
using TechConf.Services.Contracts;

namespace TechConf.Services.Implementations
{
    public class MailService : IMailService
    {
        private readonly MailSettingsOptions options;
        public MailService(IOptions<MailSettingsOptions> options)
        {
            this.options = options.Value;
        }

        public async void SendMailAsync(MailData mailData)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(options.SenderName, options.SenderEmail));
                message.To.Add(new MailboxAddress(mailData.EmailToName, mailData.EmailToId));
                message.Subject = mailData.EmailSubject; ;
                message.Body = new TextPart() { Text = mailData.EmailBody };

                using (var client = new SmtpClient())
                {
                    client.Connect(options.Server, options.Port, false);
                    await client.AuthenticateAsync(options.SenderEmail, options.Password);
                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
            }catch(Exception ex)
            {

            }
         }

    }
}
