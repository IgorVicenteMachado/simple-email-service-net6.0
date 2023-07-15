using MailKit.Net.Smtp;
using MimeKit;

namespace etmai.aspnet6.email.Services
{
    public interface IEmailService
    {
        bool SendEmail(string from, string body, string subject = "Conexão através do Site");
    }
    public class EmailService : IEmailService
    {
        public bool SendEmail(string from, string body, string? subject)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(SecretsValues.emailTo));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            try
            {
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(SecretsValues.smtpUser, SecretsValues.smtpPassword);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
