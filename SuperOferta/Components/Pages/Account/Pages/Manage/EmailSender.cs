using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace SuperOferta.Components.Pages.Account.Pages.Manage
{
    public class EmailSender : IEmailSender<IdentityUser>
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = "cioncimatias2@gmail.com";
        private readonly string _smtpPass = "ytyv eivt pojq jldd";
        public async Task SendConfirmationLinkAsync(IdentityUser user, string email, string callbackUrl)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("cioncimatias2@gmail.com", "ytyv eivt pojq jldd"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("tu_correo@gmail.com"),
                Subject = "Confirma tu cuenta",
                Body = $"<p>Por favor confirma tu cuenta haciendo clic en <a href='{callbackUrl}'>este enlace</a></p>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);
            await smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendPasswordResetLinkAsync(IdentityUser user, string email, string resetLink)
        {
            await SendEmailAsync(email, "Restablece tu contraseña",
                $"<p>Por favor restablece tu contraseña haciendo clic en <a href='{resetLink}'>este enlace</a>.</p>");
        }

        public async Task SendPasswordResetCodeAsync(IdentityUser user, string email, string resetCode)
        {
            await SendEmailAsync(email, "Código para restablecer contraseña",
                $"<p>Tu código para restablecer la contraseña es: <strong>{resetCode}</strong>.</p>");
        }

        private async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
        {
            using var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUser, _smtpPass),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUser),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}