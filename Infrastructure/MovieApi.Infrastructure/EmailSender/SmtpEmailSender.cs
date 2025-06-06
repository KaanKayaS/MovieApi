using Microsoft.Extensions.Configuration;
using MovieApi.Application.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Infrastructure.EmailSender
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public SmtpEmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpHost = configuration["Smtp:Host"];
            var smtpPort = int.Parse(configuration["Smtp:Port"]);
            var smtpUser = configuration["Smtp:UserName"];
            var smtpPass = configuration["Smtp:Password"];

            using var client = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUser),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}
