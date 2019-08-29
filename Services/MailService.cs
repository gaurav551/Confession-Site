using Microsoft.Extensions.Logging;

namespace NepConfess.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService>  _logger;
        public MailService (ILogger<MailService> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string to, string subject, string message,string by)
        {
            //log the message
            _logger.LogInformation($"To: {to} Subject;{subject} Message : {message} by{by} ");
        }
    }
}