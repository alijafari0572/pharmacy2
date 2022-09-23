using System.Threading.Tasks;

namespace pharmacy2.Repositories
{
    public interface IMessageSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false);
    }
}