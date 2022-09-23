using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace pharmacy2.Repositories
{
    public class MessageSender : IMessageSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false)
        {
            using (var client = new SmtpClient())
            {
                var credentials = new NetworkCredential()
                {
                    UserName = "wikidaroo", // without @gmail.com
                    Password = "yjsmwzymrjcawere"
                };

                client.Credentials = credentials;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                //client.UseDefaultCredentials = false;

                using var emailMessage = new MailMessage()
                {
                    To = { new MailAddress(toEmail) },
                    From = new MailAddress("wikidaroo@gmail.com"), // with @gmail.com
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isMessageHtml
                };

                client.Send(emailMessage);
            }

            return Task.CompletedTask;
        }
    }
}