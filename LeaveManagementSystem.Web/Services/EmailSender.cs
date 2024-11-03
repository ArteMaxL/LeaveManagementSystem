﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagementSystem.Web.Services;

public class EmailSender(IConfiguration _configuration) : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var fromAddress = _configuration.GetSection("EmailSettings:DefaultEmailAddress").Value ?? 
            throw new InvalidDataException();
        var smtpServer = _configuration.GetSection("EmailSettings:Server").Value ?? 
            throw new InvalidDataException();
        var smtpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);

        var message = new MailMessage 
        {
            From = new MailAddress(fromAddress),  
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        message.To.Add(new MailAddress(email));

        using var client = new SmtpClient(smtpServer, smtpPort);
        await client.SendMailAsync(message);
    }
}
