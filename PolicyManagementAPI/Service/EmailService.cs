﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using PolicyManagementAPI.Model;

namespace PolicyManagementAPI.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            this._emailSettings = emailSettings.Value;
        }
    
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmailId));
            email.Subject = mailRequest.EmailSubject;

            var builder = new BodyBuilder();

            builder.HtmlBody = mailRequest.EmailBody;
            email.Body = builder.ToMessageBody();

            using var smpt = new SmtpClient();

            smpt.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            smpt.Authenticate(_emailSettings.Email, _emailSettings.Password);
            await smpt.SendAsync(email);
            smpt.Disconnect(true);
           
        }
    }
}
