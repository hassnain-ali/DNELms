using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DNELms.WebFramework.EmailSend
{
    class EmailSender : IEmailSender
    {
        readonly SmtpClient smtpClient;
        public EmailSender(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage message = new();
            message.From = new MailAddress(((NetworkCredential)smtpClient.Credentials).UserName);
            message.To.Add(email);
            message.Subject = subject;
            message.Body = htmlMessage;
            smtpClient.SendMailAsync(message);
            return Task.CompletedTask;
        }
    }
}
