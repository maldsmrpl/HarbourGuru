using HarbourGuru.MVC.Helpers;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace HarbourGuru.MVC.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _email;
        public EmailSender(IOptions<SmtpSettings> config)
        {
            _email = new SmtpSettings()
            {
                SmtpServer = config.Value.SmtpServer,
                SmtpPort = config.Value.SmtpPort,
                SmtpUsername = config.Value.SmtpUsername,
                SmtpPassword = config.Value.SmtpPassword
            };
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MaldsShop", _email.SmtpUsername));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_email.SmtpServer, _email.SmtpPort, true);
                    await client.AuthenticateAsync(_email.SmtpUsername, _email.SmtpPassword);

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email. Error: {ex.Message}");
                }
            }
        }
    }
}
