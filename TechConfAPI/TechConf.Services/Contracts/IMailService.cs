using TechConf.Models.DTO;

namespace TechConf.Services.Contracts
{
    public interface IMailService
    {
      void SendMailAsync(MailData mailData);
    }
}
